package com.security;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.os.Environment;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.*;

import java.io.*;

/**
 * User: Terry
 * Date: 8/20/13
 * Time: 4:08 AM
 * Login form
 */
public class LoginActivity extends Activity {
    public final static String EXTRA_PWD = "com.security.clearpwd";
    private static final int FILE_SELECT_CODE = 10101;
    private File _dataFile;

    private EditText _txtPwd;
    private TextView _lbStatus;
    private LoginActivity _activity;
    private Button _btnLogin;
    private String _dataFilePath = "";
    private String _sdRoot = Environment.getExternalStorageDirectory().getPath();
    private String _configFilePath = _sdRoot + "/SecurityCenter.config";

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.login);
        _activity = this;

        // Controls
        _txtPwd = (EditText)findViewById(R.id.txtPwd);
        _lbStatus = (TextView)findViewById(R.id.lbStatus);
        _btnLogin = (Button)findViewById(R.id.btnLogin);
    }

    @Override
    protected void onStart() {
        super.onStart();
        clearContent();
        refreshUI();
    }

    private void refreshUI(){
        if (locateDataFile()){
            if (DataManager.loadDataFile(_dataFile) == false){
                Utils.ShowMessage(getApplicationContext(), R.string.data_file_load_failure);
            }
            _btnLogin.setEnabled(true);
            _lbStatus.setText(getString(R.string.data_file_ready) + "\n" + _dataFile.getPath());
        } else {
            _btnLogin.setEnabled(false);
            _lbStatus.setText(getString(R.string.data_file_not_found) + "\n" + _dataFilePath);
        }
    }

    @Override
    protected void onPause() {
        super.onPause();
        clearContent();
    }

    @Override
    protected void onStop() {
        super.onStop();
        clearContent();
    }

    public void btnLocate_Clicked(View view){
        showFileChooser();
    }

    public void btnLogin_Clicked(View view){
        try{
            String pwdClear = _txtPwd.getText().toString();
            SecurityCipher cipher = new SecurityCipher(pwdClear);
            _txtPwd.setText("");

            if (verifyPwd(cipher) == false){
                Utils.ShowMessage(getApplicationContext(), R.string.pwd_wrong);
                return;
            }

            Utils.ShowMessage(getApplicationContext(), R.string.pwd_verified);

            // Hide keyboard
            InputMethodManager imm = (InputMethodManager)getSystemService(INPUT_METHOD_SERVICE);
            imm.hideSoftInputFromWindow(_txtPwd.getWindowToken(), 0);

            // Show note list
            Intent intent = new Intent(this, NoteListActivity.class);
            intent.putExtra(EXTRA_PWD, pwdClear);
            startActivity(intent);

            cipher.dispose();
        } catch (Exception e){
            new AlertDialog.Builder(_activity)
                    .setTitle("Error")
                    .setMessage(e.getMessage())
                    .setNegativeButton("返回", null)
                    .show();
        }
    }

    private boolean verifyPwd(SecurityCipher cipher){
        return cipher.getPasswordHash().equals(DataManager.getPwdHash());
    }

    private boolean locateDataFile() {
        boolean foundData = false;

        // Config file
        File configFile = new File(_configFilePath);

        InputStream inputStream = null;
        try {
            inputStream = new BufferedInputStream(new FileInputStream(configFile));
        } catch (FileNotFoundException e) {
            return false;
        }
        InputStreamReader inputStreamReader;
        try {
            inputStreamReader = new InputStreamReader(inputStream, "UTF-8");
        } catch (UnsupportedEncodingException e1) {
            return false;
        }
        BufferedReader reader = new BufferedReader(inputStreamReader);
        try {
            _dataFilePath = reader.readLine();
        } catch (IOException e) {
            return false;
        }

        File file = new File(_dataFilePath);
        if (file.exists() && file.isFile()){
            foundData = true;
            _dataFile = file;
        }
        return foundData;
    }

    private void clearContent(){
        _txtPwd.setText("");
    }


    private void showFileChooser() {
        Intent intent = new Intent(Intent.ACTION_GET_CONTENT);
        intent.setType("*/*");
        intent.addCategory(Intent.CATEGORY_OPENABLE);

        try {
            startActivityForResult( Intent.createChooser(intent, "Select a File to Upload"), FILE_SELECT_CODE);
        } catch (android.content.ActivityNotFoundException ex) {
            Toast.makeText(this, "Please install a File Manager.",  Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data)  {
        switch (requestCode) {
            case FILE_SELECT_CODE:
                if (resultCode == RESULT_OK) {
                    Uri uri = data.getData();
                    _dataFilePath = FileUtils.getPath(this, uri);
                    writeDataFilePathToConfig(_dataFilePath);

                    refreshUI();
                }
                break;
        }
        super.onActivityResult(requestCode, resultCode, data);
    }

    private void writeDataFilePathToConfig(String dataFilePath) {
        File targetFile = new File(_configFilePath);
        OutputStreamWriter osw;
        try{
            if(!targetFile.exists()){
                targetFile.createNewFile();
            }
            osw = new OutputStreamWriter(new FileOutputStream(targetFile),"utf-8");
            osw.write(dataFilePath);
            osw.flush();
            osw.close();
        } catch (Exception e) {

        }

    }
}


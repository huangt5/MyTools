package com.security;

import android.app.Activity;
import android.app.AlertDialog;
import android.os.Bundle;
import android.text.Editable;
import android.text.TextWatcher;
import android.view.View;
import android.widget.*;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * User: Terry
 * Date: 8/21/13
 * Time: 12:03 AM
 * Show all notes names
 */
public class NoteListActivity extends Activity {
    private NoteListActivity _activity;
    private ArrayList<HashMap<String, String>> _allNotes;
    private ArrayList<HashMap<String, String>> _currentList;
    private EditText _txtKey;
    private ListView _listNotes;
    private Button _btnSearch;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.note_list);
        _activity = this;

        SecurityCipher cipher = new SecurityCipher(getIntent().getStringExtra(LoginActivity.EXTRA_PWD));
        _txtKey = (EditText)findViewById(R.id.txtKey);
        _listNotes = (ListView) findViewById(R.id.list);
        _btnSearch = (Button)findViewById(R.id.btnSearch);

        _txtKey.addTextChangedListener(new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence charSequence, int i, int i2, int i3) {
            }

            @Override
            public void onTextChanged(CharSequence charSequence, int i, int i2, int i3) {
                _btnSearch.setEnabled(!_txtKey.getText().toString().equals(""));
            }

            @Override
            public void afterTextChanged(Editable editable) {
            }
        });
        _btnSearch.setEnabled(false);


        _allNotes = DataManager.getAllNotes();
        // decrypt contents
        for (HashMap<String, String> note : _allNotes){
            note.put("name", cipher.decrypt(note.get("name")));
            note.put("note", cipher.decrypt(note.get("note")));
            note.put("tags", cipher.decrypt(note.get("tags")));
        }
        cipher.dispose();
    }

    @Override
    protected void onPause() {
        super.onPause();
        ClearContent();
        finish();
    }

    @Override
    protected void onStop() {
        super.onStop();
        ClearContent();
        finish();
    }

    public void btnSearch_Clicked(View view){
        _currentList = filterNotes(_txtKey.getText().toString());
        refreshListView();
    }

    private ArrayList<HashMap<String, String>> filterNotes(String key){
        if (key == null || key.trim().equals("")){
            return _allNotes;
        }
        ArrayList<HashMap<String, String>> newList = new ArrayList<HashMap<String, String>>();
        for (HashMap<String, String> item : _allNotes){
            if (item.get("name").contains(key) ||
                    item.get("note").contains(key) ||
                    item.get("tags").contains(key)){
                newList.add(item);
            }
        }
        return newList;
    }

    private void refreshListView() {
        SimpleAdapter listAdapter = new SimpleAdapter(this,
                _currentList,
                R.layout.note_list_item,
                new String[]{"name"},
                new int[]{R.id.lbName}
        );


        _listNotes.setAdapter(listAdapter);

        _listNotes.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                String name = _currentList.get(position).get("name");
                String note = _currentList.get(position).get("note");

                new AlertDialog.Builder(_activity)
                        .setTitle(name)
                        .setMessage(note)
                        .setNegativeButton(R.string.back, null)
                        .show();
            }
        });
    }

    private void ClearContent(){
        if (_allNotes != null){
            for (HashMap<String, String> item : _allNotes){
                item.put("name", "");
                item.put("note", "");
                item.put("tags", "");
                item.clear();
            }
            _allNotes.clear();
        }
        _allNotes = null;
        if (_currentList != null){
            _currentList.clear();
            _currentList = null;
        }
    }
}
package com.security;

import android.util.Base64;

import javax.crypto.Cipher;
import javax.crypto.spec.IvParameterSpec;
import javax.crypto.spec.SecretKeySpec;
import java.security.MessageDigest;

/**
 * Used to compute password hash, encrypt and decrypt.
 * User: terry
 * Date: 7/12/12
 * Time: 1:02 PM
 */
public class SecurityCipher {
    private String _pwdClear;
    private MessageDigest _sha512;
    private MessageDigest _sha256;
    private SecretKeySpec _key;
    private IvParameterSpec _iv;
    private Cipher _cipher;

    public SecurityCipher(String pwdClear){
        _pwdClear = pwdClear;
        try {
            _sha512 = MessageDigest.getInstance("SHA-512");
            _sha256 = MessageDigest.getInstance("SHA-256");

            _sha256.update(_pwdClear.getBytes("UTF-8"));
            byte[] key = _sha256.digest();
            _sha256.update(key);
            byte[] hasedKey = _sha256.digest();
            byte[] iv = new byte[16];
            System.arraycopy(hasedKey, 0, iv, 0, 16);

            _key = new SecretKeySpec(key, "AES");
            _iv = new IvParameterSpec(iv);

            _cipher = Cipher.getInstance("AES/CBC/PKCS5Padding");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }

    public String getPasswordHash(){
        try {
            _sha512.update(_pwdClear.getBytes("UTF-8"));
            byte[] pwdHashed = _sha512.digest();
            String pwdHasedBase64 = Base64.encodeToString(pwdHashed, Base64.NO_WRAP);
            return pwdHasedBase64;
        } catch (Exception e) {
            String err = e.getMessage();
            e.printStackTrace();
            return "Failed to compute hash.";
        }
    }

    public String decrypt(String encryptedText){
        try {
            _cipher.init(Cipher.DECRYPT_MODE, _key, _iv);
            byte[] decryptedText = _cipher.doFinal(Base64.decode(encryptedText, Base64.DEFAULT));

            return new String(decryptedText);
        } catch (Exception e) {
            e.printStackTrace();
            return "Failed to decrypt.";
        }
    }

    public void dispose(){
        _pwdClear = "";
        _key = null;
        _iv = null;
    }
}

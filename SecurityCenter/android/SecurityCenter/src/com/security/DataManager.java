package com.security;

import org.w3c.dom.Document;
import org.w3c.dom.Element;
import org.w3c.dom.NodeList;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;

/**
 * User: Terry
 * Date: 8/21/13
 * Time: 1:25 AM
 * Singleton class to manage security data
 */
public class DataManager {
    private static Element _rootElement;

    private DataManager(){

    }

    public static boolean loadDataFile(File file){
        try {
            DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
            DocumentBuilder builder = factory.newDocumentBuilder();
            Document document = builder.parse(file);
            _rootElement = document.getDocumentElement();
        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
        return true;
    }

    public static String getPwdHash(){
        Element securityElement = (Element) _rootElement.getElementsByTagName("Security").item(0);
        return securityElement.getElementsByTagName("Hash").item(0).getFirstChild().getNodeValue();
    }

    public static ArrayList<HashMap<String, String>> getAllNotes(){
        Element notesElement = (Element) _rootElement.getElementsByTagName("Notes").item(0);
        NodeList noteList =  notesElement.getElementsByTagName("Note2");
        ArrayList<HashMap<String, String>> allNotes = new ArrayList<HashMap<String, String>>();
        for (int i = 0; i < noteList.getLength(); i++){
            Element noteElement = (Element)noteList.item(i);
            HashMap<String, String> item = new HashMap<String, String>();
            item.put("name", noteElement.getElementsByTagName("Name").item(0).getFirstChild().getNodeValue());
            item.put("note", noteElement.getElementsByTagName("Notes").item(0).getFirstChild().getNodeValue());
            item.put("tags", noteElement.getElementsByTagName("Tags").item(0).getFirstChild().getNodeValue());
            allNotes.add(item);
        }
        return allNotes;
    }

}

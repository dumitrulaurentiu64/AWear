package com.example.awearapp.Models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.UUID;

public class Medic {
    @Expose
    @SerializedName("id")
    private String id;

    @Expose
    @SerializedName("userName")
    private String userName;

    @Expose
    @SerializedName("email")
    private String email;

    @Expose
    @SerializedName("fieldOfPractice")
    private String fieldOfPractice;

    public Medic(String id, String userName, String email, String fieldOfPractice) {
        this.id = id;
        this.userName = userName;
        this.email = email;
        this.fieldOfPractice = fieldOfPractice;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getUserName() {
        return userName;
    }

    public void setUserName(String userName) {
        this.userName = userName;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getFieldOfPractice() {
        return fieldOfPractice;
    }

    public void setFieldOfPractice(String fieldOfPractice) {
        this.fieldOfPractice = fieldOfPractice;
    }
}

package com.example.awearapp.Models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class LoginResponse {

    @SerializedName("token")
    @Expose
    public String token;
    @SerializedName("user")
    @Expose
    public Pacient user;

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }

    public Pacient getUser() {
        return user;
    }

    public void setUser(Pacient user) {
        this.user = user;
    }

    public LoginResponse(String token, Pacient user) {
        this.token = token;
        this.user = user;
    }
}


package com.example.awearapp.Models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class SensorDataResponse {
    @SerializedName("id")
    @Expose
    public String id;
    @SerializedName("timeStamp")
    @Expose
    public String timeStamp;
    @SerializedName("temperature")
    @Expose
    public Integer temperature;
    @SerializedName("humidity")
    @Expose
    public Integer humidity;
    @SerializedName("pulse")
    @Expose
    public Integer pulse;
    @SerializedName("ekgValue")
    @Expose
    public Integer ekgValue;
    @SerializedName("pacientId")
    @Expose
    public String pacientId;
    @SerializedName("sensorDataOfPacient")
    @Expose
    public Pacient sensorDataOfPacient;

    public SensorDataResponse(String id, String timeStamp, Integer temperature, Integer humidity, Integer pulse, Integer ekgValue, String pacientId, Pacient sensorDataOfPacient) {
        this.id = id;
        this.timeStamp = timeStamp;
        this.temperature = temperature;
        this.humidity = humidity;
        this.pulse = pulse;
        this.ekgValue = ekgValue;
        this.pacientId = pacientId;
        this.sensorDataOfPacient = sensorDataOfPacient;
    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getTimeStamp() {
        return timeStamp;
    }

    public void setTimeStamp(String timeStamp) {
        this.timeStamp = timeStamp;
    }

    public Integer getTemperature() {
        return temperature;
    }

    public void setTemperature(Integer temperature) {
        this.temperature = temperature;
    }

    public Integer getHumidity() {
        return humidity;
    }

    public void setHumidity(Integer humidity) {
        this.humidity = humidity;
    }

    public Integer getPulse() {
        return pulse;
    }

    public void setPulse(Integer pulse) {
        this.pulse = pulse;
    }

    public Integer getEkgValue() {
        return ekgValue;
    }

    public void setEkgValue(Integer ekgValue) {
        this.ekgValue = ekgValue;
    }

    public String getPacientId() {
        return pacientId;
    }

    public void setPacientId(String pacientId) {
        this.pacientId = pacientId;
    }

    public Pacient getSensorDataOfPacient() {
        return sensorDataOfPacient;
    }

    public void setSensorDataOfPacient(Pacient sensorDataOfPacient) {
        this.sensorDataOfPacient = sensorDataOfPacient;
    }
}

package com.example.awearapp.Models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class SensorData {
    @SerializedName("Temperature")
    @Expose
    public Double temperature;
    @SerializedName("Humidity")
    @Expose
    public Double humidity;
    @SerializedName("Pulse")
    @Expose
    public Double pulse;
    @SerializedName("EKGValue")
    @Expose
    public Double eKGValue;

    public Double getTemperature() {
        return temperature;
    }

    public void setTemperature(Double temperature) {
        this.temperature = temperature;
    }

    public Double getHumidity() {
        return humidity;
    }

    public void setHumidity(Double humidity) {
        this.humidity = humidity;
    }

    public Double getPulse() {
        return pulse;
    }

    public void setPulse(Double pulse) {
        this.pulse = pulse;
    }

    public Double geteKGValue() {
        return eKGValue;
    }

    public void seteKGValue(Double eKGValue) {
        this.eKGValue = eKGValue;
    }

    public SensorData(Double temperature, Double humidity, Double pulse, Double eKGValue) {
        this.temperature = temperature;
        this.humidity = humidity;
        this.pulse = pulse;
        this.eKGValue = eKGValue;
    }
}

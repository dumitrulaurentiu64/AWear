package com.example.awearapp.Models;
import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

import java.util.List;

public class PacientResponse {
    @SerializedName("id")
    @Expose
    public String id;
    @SerializedName("username")
    @Expose
    public String username;
    @SerializedName("email")
    @Expose
    public String email;
    @SerializedName("created")
    @Expose
    public String created;
    @SerializedName("cnp")
    @Expose
    public String cnp;
    @SerializedName("lastName")
    @Expose
    public String lastName;
    @SerializedName("firstName")
    @Expose
    public String firstName;
    @SerializedName("address")
    @Expose
    public String address;
    @SerializedName("dateOfBirth")
    @Expose
    public String dateOfBirth;
    @SerializedName("telephoneNumber")
    @Expose
    public String telephoneNumber;
    @SerializedName("height")
    @Expose
    public Integer height;
    @SerializedName("weight")
    @Expose
    public Integer weight;
    @SerializedName("gender")
    @Expose
    public String gender;
    @SerializedName("medic")
    @Expose
    public Object medic;
    @SerializedName("medicId")
    @Expose
    public String medicId;
    @SerializedName("sensorDataList")
    @Expose
    public List<Object> sensorDataList = null;
    @SerializedName("warnings")
    @Expose
    public List<Object> warnings = null;
    @SerializedName("recommandations")
    @Expose
    public List<Object> recommandations = null;

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getCreated() {
        return created;
    }

    public void setCreated(String created) {
        this.created = created;
    }

    public String getCnp() {
        return cnp;
    }

    public void setCnp(String cnp) {
        this.cnp = cnp;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getAddress() {
        return address;
    }

    public void setAddress(String address) {
        this.address = address;
    }

    public String getDateOfBirth() {
        return dateOfBirth;
    }

    public void setDateOfBirth(String dateOfBirth) {
        this.dateOfBirth = dateOfBirth;
    }

    public String getTelephoneNumber() {
        return telephoneNumber;
    }

    public void setTelephoneNumber(String telephoneNumber) {
        this.telephoneNumber = telephoneNumber;
    }

    public Integer getHeight() {
        return height;
    }

    public void setHeight(Integer height) {
        this.height = height;
    }

    public Integer getWeight() {
        return weight;
    }

    public void setWeight(Integer weight) {
        this.weight = weight;
    }

    public String getGender() {
        return gender;
    }

    public void setGender(String gender) {
        this.gender = gender;
    }

    public Object getMedic() {
        return medic;
    }

    public void setMedic(Object medic) {
        this.medic = medic;
    }

    public String getMedicId() {
        return medicId;
    }

    public void setMedicId(String medicId) {
        this.medicId = medicId;
    }

    public List<Object> getSensorDataList() {
        return sensorDataList;
    }

    public void setSensorDataList(List<Object> sensorDataList) {
        this.sensorDataList = sensorDataList;
    }

    public List<Object> getWarnings() {
        return warnings;
    }

    public void setWarnings(List<Object> warnings) {
        this.warnings = warnings;
    }

    public List<Object> getRecommandations() {
        return recommandations;
    }

    public void setRecommandations(List<Object> recommandations) {
        this.recommandations = recommandations;
    }

    public PacientResponse(String id, String username, String email, String created, String cnp, String lastName, String firstName, String address, String dateOfBirth, String telephoneNumber, Integer height, Integer weight, String gender, Object medic, String medicId, List<Object> sensorDataList, List<Object> warnings, List<Object> recommandations) {
        this.id = id;
        this.username = username;
        this.email = email;
        this.created = created;
        this.cnp = cnp;
        this.lastName = lastName;
        this.firstName = firstName;
        this.address = address;
        this.dateOfBirth = dateOfBirth;
        this.telephoneNumber = telephoneNumber;
        this.height = height;
        this.weight = weight;
        this.gender = gender;
        this.medic = medic;
        this.medicId = medicId;
        this.sensorDataList = sensorDataList;
        this.warnings = warnings;
        this.recommandations = recommandations;
    }
}

package com.example.awearapp.Models;

import com.google.gson.annotations.Expose;
import com.google.gson.annotations.SerializedName;

public class Pacient {
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
    @SerializedName("medicId")
    @Expose
    public String medicId;
    @SerializedName("medic")
    @Expose
    public Object medic;
    @SerializedName("sensorDataList")
    @Expose
    public Object sensorDataList;
    @SerializedName("warnings")
    @Expose
    public Object warnings;
    @SerializedName("recommandations")
    @Expose
    public Object recommandations;
    @SerializedName("cnp")
    @Expose
    public String cnp;
    @SerializedName("lastName")
    @Expose
    public String lastName;
    @SerializedName("firstName")
    @Expose
    public String firstName;
    @SerializedName("created")
    @Expose
    public String created;
    @SerializedName("userRoles")
    @Expose
    public Object userRoles;
    @SerializedName("id")
    @Expose
    public String id;
    @SerializedName("userName")
    @Expose
    public String userName;
    @SerializedName("normalizedUserName")
    @Expose
    public String normalizedUserName;
    @SerializedName("email")
    @Expose
    public String email;
    @SerializedName("normalizedEmail")
    @Expose
    public String normalizedEmail;
    @SerializedName("emailConfirmed")
    @Expose
    public Boolean emailConfirmed;
    @SerializedName("passwordHash")
    @Expose
    public String passwordHash;
    @SerializedName("securityStamp")
    @Expose
    public String securityStamp;
    @SerializedName("concurrencyStamp")
    @Expose
    public String concurrencyStamp;
    @SerializedName("phoneNumber")
    @Expose
    public Object phoneNumber;
    @SerializedName("phoneNumberConfirmed")
    @Expose
    public Boolean phoneNumberConfirmed;
    @SerializedName("twoFactorEnabled")
    @Expose
    public Boolean twoFactorEnabled;
    @SerializedName("lockoutEnd")
    @Expose
    public Object lockoutEnd;
    @SerializedName("lockoutEnabled")
    @Expose
    public Boolean lockoutEnabled;
    @SerializedName("accessFailedCount")
    @Expose
    public Integer accessFailedCount;

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

    public String getMedicId() {
        return medicId;
    }

    public void setMedicId(String medicId) {
        this.medicId = medicId;
    }

    public Object getMedic() {
        return medic;
    }

    public void setMedic(Object medic) {
        this.medic = medic;
    }

    public Object getSensorDataList() {
        return sensorDataList;
    }

    public void setSensorDataList(Object sensorDataList) {
        this.sensorDataList = sensorDataList;
    }

    public Object getWarnings() {
        return warnings;
    }

    public void setWarnings(Object warnings) {
        this.warnings = warnings;
    }

    public Object getRecommandations() {
        return recommandations;
    }

    public void setRecommandations(Object recommandations) {
        this.recommandations = recommandations;
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

    public String getCreated() {
        return created;
    }

    public void setCreated(String created) {
        this.created = created;
    }

    public Object getUserRoles() {
        return userRoles;
    }

    public void setUserRoles(Object userRoles) {
        this.userRoles = userRoles;
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

    public String getNormalizedUserName() {
        return normalizedUserName;
    }

    public void setNormalizedUserName(String normalizedUserName) {
        this.normalizedUserName = normalizedUserName;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getNormalizedEmail() {
        return normalizedEmail;
    }

    public void setNormalizedEmail(String normalizedEmail) {
        this.normalizedEmail = normalizedEmail;
    }

    public Boolean getEmailConfirmed() {
        return emailConfirmed;
    }

    public void setEmailConfirmed(Boolean emailConfirmed) {
        this.emailConfirmed = emailConfirmed;
    }

    public String getPasswordHash() {
        return passwordHash;
    }

    public void setPasswordHash(String passwordHash) {
        this.passwordHash = passwordHash;
    }

    public String getSecurityStamp() {
        return securityStamp;
    }

    public void setSecurityStamp(String securityStamp) {
        this.securityStamp = securityStamp;
    }

    public String getConcurrencyStamp() {
        return concurrencyStamp;
    }

    public void setConcurrencyStamp(String concurrencyStamp) {
        this.concurrencyStamp = concurrencyStamp;
    }

    public Object getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(Object phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public Boolean getPhoneNumberConfirmed() {
        return phoneNumberConfirmed;
    }

    public void setPhoneNumberConfirmed(Boolean phoneNumberConfirmed) {
        this.phoneNumberConfirmed = phoneNumberConfirmed;
    }

    public Boolean getTwoFactorEnabled() {
        return twoFactorEnabled;
    }

    public void setTwoFactorEnabled(Boolean twoFactorEnabled) {
        this.twoFactorEnabled = twoFactorEnabled;
    }

    public Object getLockoutEnd() {
        return lockoutEnd;
    }

    public void setLockoutEnd(Object lockoutEnd) {
        this.lockoutEnd = lockoutEnd;
    }

    public Boolean getLockoutEnabled() {
        return lockoutEnabled;
    }

    public void setLockoutEnabled(Boolean lockoutEnabled) {
        this.lockoutEnabled = lockoutEnabled;
    }

    public Integer getAccessFailedCount() {
        return accessFailedCount;
    }

    public void setAccessFailedCount(Integer accessFailedCount) {
        this.accessFailedCount = accessFailedCount;
    }

    public Pacient(String address, String dateOfBirth, String telephoneNumber, Integer height, Integer weight, String gender, String medicId, Object medic, Object sensorDataList, Object warnings, Object recommandations, String cnp, String lastName, String firstName, String created, Object userRoles, String id, String userName, String normalizedUserName, String email, String normalizedEmail, Boolean emailConfirmed, String passwordHash, String securityStamp, String concurrencyStamp, Object phoneNumber, Boolean phoneNumberConfirmed, Boolean twoFactorEnabled, Object lockoutEnd, Boolean lockoutEnabled, Integer accessFailedCount) {
        this.address = address;
        this.dateOfBirth = dateOfBirth;
        this.telephoneNumber = telephoneNumber;
        this.height = height;
        this.weight = weight;
        this.gender = gender;
        this.medicId = medicId;
        this.medic = medic;
        this.sensorDataList = sensorDataList;
        this.warnings = warnings;
        this.recommandations = recommandations;
        this.cnp = cnp;
        this.lastName = lastName;
        this.firstName = firstName;
        this.created = created;
        this.userRoles = userRoles;
        this.id = id;
        this.userName = userName;
        this.normalizedUserName = normalizedUserName;
        this.email = email;
        this.normalizedEmail = normalizedEmail;
        this.emailConfirmed = emailConfirmed;
        this.passwordHash = passwordHash;
        this.securityStamp = securityStamp;
        this.concurrencyStamp = concurrencyStamp;
        this.phoneNumber = phoneNumber;
        this.phoneNumberConfirmed = phoneNumberConfirmed;
        this.twoFactorEnabled = twoFactorEnabled;
        this.lockoutEnd = lockoutEnd;
        this.lockoutEnabled = lockoutEnabled;
        this.accessFailedCount = accessFailedCount;
    }
}

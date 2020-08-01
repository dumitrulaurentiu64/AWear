### *API for AWear ecosystem*
---------------------------------

Here is the source code for the Cloud submodule of AWear.

The app is hosted on Azure Cloud.

##### Contributing:
-------------------
  - Necessary software
    - `Visual Studio >= 15.9.9 (15.9.11 recommeded)`
    - `ASP.Net Core 2.1`
    - `Entity Framework`
    - `Opt Postman for testing the API` -> [Download link](https://www.getpostman.com/)
  - Rules
    - Adhere to the current architecture
    - New features are added through a pull request to @adrianB3

##### Architecture:
-------------------
###### Endpoints
```
/api/login
/api/pacients/{id}/warnings
/api/pacients/{id}/recommandations
/api/pacients/{id}/sensor_data
/api/pacients/{id}/pacient_file
/api/medics/{id}/pacients_list
/api/medics/{id}/pacients_list/{pacient_id}
```

##### Resources:
----------------
  - [Link to a freecodecamp walk-through on how to build an API in ASP.Net Core](https://medium.freecodecamp.org/an-awesome-guide-on-how-to-build-restful-apis-with-asp-net-core-87b818123e28?fbclid=IwAR2lzFAIOOebBH5AjNecjrGyY_bgj1hIJSaM8YETwpIfKYaCzSjY8-ICUtc)
  - [Link to learn about how to make relationships between tables in Entity framework](https://www.learnentityframeworkcore.com/relationships)

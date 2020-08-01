package retro;

public class ApiUtil {

    private static final String BASE_URL = "https://awearapi.azurewebsites.net/api/";
    public static RetrofitInterface getServiceClass() {
        return RetrofitAPI.getRetrofit(BASE_URL).create(RetrofitInterface.class);
    }
}

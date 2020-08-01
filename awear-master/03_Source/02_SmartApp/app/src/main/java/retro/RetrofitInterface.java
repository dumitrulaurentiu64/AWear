package retro;

import com.example.awearapp.Models.LoginRequest;
import com.example.awearapp.Models.LoginResponse;
import com.example.awearapp.Models.Medic;
import com.example.awearapp.Models.Pacient;
import com.example.awearapp.Models.PacientResponse;
import com.example.awearapp.Models.SensorData;
import com.example.awearapp.Models.SensorDataResponse;

import java.util.List;

import io.reactivex.Single;
import retrofit2.Call;
import retrofit2.http.Body;
import retrofit2.http.Field;
import retrofit2.http.FormUrlEncoded;
import retrofit2.http.GET;
import retrofit2.http.POST;
import retrofit2.http.Path;
import retrofit2.http.Query;

public interface RetrofitInterface {

    @POST("auth/login")
    Call<LoginResponse> userLogin(@Body LoginRequest loginRequest);

    @POST("SensorData")
    Call<SensorDataResponse> postSensorData(@Query("PacientId") String pacientId, @Body SensorData sensorData);

    @GET("pacients/{id}")
    Call<PacientResponse> getPacientProfile(@Path("id") String pacientId);
}

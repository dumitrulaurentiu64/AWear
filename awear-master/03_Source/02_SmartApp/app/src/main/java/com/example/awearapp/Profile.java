package com.example.awearapp;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.example.awearapp.Models.LoginRequest;
import com.example.awearapp.Models.LoginResponse;
import com.example.awearapp.Models.Pacient;
import com.example.awearapp.Models.PacientResponse;
import com.example.awearapp.R;

import retro.ApiUtil;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class Profile extends Fragment {
    Button done;
    View view;
    EditText username, email, phone, pass, medic;
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
    view=inflater.inflate(R.layout.fragment_profile, container, false);
    done=view.findViewById(R.id.doneBtn);
        done.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                onClickDone(v);
            }
        });


        username = (EditText) view.findViewById(R.id.UserName);
        email = (EditText) view.findViewById(R.id.Email);
        phone = (EditText) view.findViewById(R.id.phoneText);
        pass = (EditText) view.findViewById(R.id.passText);
        medic = (EditText) view.findViewById(R.id.doctorText);


        Call<PacientResponse> call = ApiUtil.getServiceClass().getPacientProfile(LogInActivity.pacientId);

        call.enqueue(new Callback<PacientResponse>() {
            @Override
            public void onResponse(Call<PacientResponse> call, Response<PacientResponse> response) {
                PacientResponse res = response.body();
                if(res != null){

                    username.setText(res.getUsername());
                    email.setText(res.getEmail());
                    phone.setText(res.getTelephoneNumber());
                    pass.setText("");
                    medic.setText(res.getMedicId());
                }


            }

            @Override
            public void onFailure(Call<PacientResponse> call, Throwable t) {

            }
        });


        return view;

    }
    public void onClickDone(View view)
    {
        Call<PacientResponse> call = ApiUtil.getServiceClass().getPacientProfile(LogInActivity.pacientId);

        call.enqueue(new Callback<PacientResponse>() {
            @Override
            public void onResponse(Call<PacientResponse> call, Response<PacientResponse> response) {
                PacientResponse res = response.body();
                if(res != null){

                    username.setText(res.getUsername());
                    email.setText(res.getEmail());
                    phone.setText(res.getTelephoneNumber());
                    pass.setText("");
                    medic.setText(res.getMedicId());
                }


            }

            @Override
            public void onFailure(Call<PacientResponse> call, Throwable t) {

            }
        });

    }
}

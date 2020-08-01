package com.example.awearapp;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.content.Context;
import android.content.Intent;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.os.Bundle;
import android.os.Handler;
import android.support.v7.app.AppCompatActivity;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.example.awearapp.Models.LoginRequest;
import com.example.awearapp.Models.LoginResponse;
import com.example.awearapp.Models.Medic;
import com.example.awearapp.Models.Pacient;
import com.example.awearapp.Models.SensorData;
import com.example.awearapp.Models.SensorDataResponse;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.util.ArrayList;
import java.util.List;
import java.util.Set;
import java.util.UUID;

import retro.ApiUtil;
import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class LogInActivity extends AppCompatActivity {

    public static class getData{
        public String humidity;
        public String temperature;
        public getData(String humidity,String temperature)
        {
            this.humidity=humidity;
            this.temperature=temperature;
        }
    }
    public static LoginResponse loginResponse;
    public static String pacientId = "";
    public static SensorData ssd = new SensorData(0.0d,0.0d,0.0d,0.0d);
    public static List<Medic> postList;
    private final String DEVICE_ADDRESS = "20:16:10:25:03:99";
    private final UUID PORT_UUID = UUID.fromString("00001101-0000-1000-8000-00805f9b34fb");//Serial Port Service ID
    private BluetoothDevice device;
    private BluetoothSocket socket;
    private OutputStream outputStream;
    private InputStream inputStream;
    boolean deviceConnected = false;
    boolean check=false;
    int x=0;
    public getData dataObj1;
    byte buffer[];
    Thread thread;
    boolean stopThread;
    TextView textView1,textView2;
    Button buttonStart;
    Button buttonLogin;
    ArrayList ecgValues=new ArrayList<>();
   public static ArrayList pulseValues;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_log_in);
        pulseValues=new ArrayList<>();
        //trebuie sters
       // pulseValues.add(145);
        textView2=(TextView )findViewById(R.id.textView2) ;
       /* ApiUtil.getServiceClass().getAllMedics().enqueue(new Callback<List<Medic>>() {
            @Override
            public void onResponse(Call<List<Medic>> call, Response<List<Medic>> response) {
                if(response.isSuccessful()){
                    postList = response.body();
                    // RVNewAdapter adapter = new RVNewAdapter(getApplicationContext(), postList);
                   // textView2.setText(postList.get(1).getEmail());
                }
            }
            @Override
            public void onFailure(Call<List<Medic>> call, Throwable t) {
                Toast.makeText(getApplicationContext(), "Error loading the data from the api.", Toast.LENGTH_SHORT);
            }
        });*/
        buttonStart = (Button) findViewById(R.id.buttonStart);
        buttonStart.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                onClickStart(v);
            }
        });
        buttonLogin = (Button) findViewById(R.id.loginbtn);
        buttonLogin.setOnClickListener(new View.OnClickListener() {
            public void onClick(View v) {
                checkLogInData(v);
            }
        });
        if(isInternetConnection()==false)
            Toast.makeText(getApplicationContext(), "Please connect to internet first!", Toast.LENGTH_SHORT).show();


    }
    public boolean BTinit() {
        boolean found = false;
        BluetoothAdapter bluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
        if (bluetoothAdapter == null) {
            Toast.makeText(getApplicationContext(), "Device doesn't Support Bluetooth", Toast.LENGTH_SHORT).show();
        }
        if (!bluetoothAdapter.isEnabled()) {
            Intent enableAdapter = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
            startActivityForResult(enableAdapter, 0);
            try {
                Thread.sleep(1000);
            } catch (InterruptedException e) {
                e.printStackTrace();
            }
        }
        Set<BluetoothDevice> bondedDevices = bluetoothAdapter.getBondedDevices();
        if (bondedDevices.isEmpty()) {
            Toast.makeText(getApplicationContext(), "Please Pair the Device first", Toast.LENGTH_SHORT).show();
        } else {
            for (BluetoothDevice iterator : bondedDevices) {
                if (iterator.getAddress().equals(DEVICE_ADDRESS)) {
                    device = iterator;
                    found = true;
                    break;
                }
            }
        }
        return found;
    }
    public boolean BTconnect() {
        boolean connected = true;
        try {
            socket = device.createRfcommSocketToServiceRecord(PORT_UUID);
            socket.connect();
        } catch (IOException e) {
            e.printStackTrace();
            connected = false;
        }
        if (connected) {
            try {
                outputStream = socket.getOutputStream();
            } catch (IOException e) {
                e.printStackTrace();
            }
            try {
                inputStream = socket.getInputStream();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
        return connected;
    }
    public void onClickStart(View v) {
        if (BTinit()) {
            if (BTconnect()) {
                deviceConnected = true;
                beginListenForData();
                textView2.append("\nConnection Opened!\n");
            }

        }
    }
    void beginListenForData() {
        final Handler handler = new Handler();
        stopThread = false;
        buffer = new byte[1024];
        final Thread thread = new Thread(new Runnable() {
            public void run() {
                while (!Thread.currentThread().isInterrupted() && !stopThread) {
                    try {
                        int byteCount = inputStream.available();
                        //System.out.println("byteCount="+byteCount);
                        if(byteCount > 50) {

                            final byte[] rawBytes = new byte[byteCount];
                            inputStream.read(rawBytes);
                            final String string = new String(rawBytes, "UTF-8");
                            // System.out.println("string="+string);
                            handler.postDelayed(new Runnable() {
                                public void run() {
                                    // textView2.append(string);
                                    /*if(string.contains("ecg"))
                                    {
                                        ecgValues.clear();
                                        String data[] = string.split(":");
                                        for(int i=0;i< data.length;i++ )
                                        ecgValues.add(Float.parseFloat(data[i]));
                                    }
                                    else if(string.contains("data")) {
                                   //         String data[] = string.split(":");
                                     //       dataObj1 = new getData(data[1], data[2]);
                                       textView2.append(string+"asta e data");
                                        }
                                    else if(string.contains("pulse")) {
                                           // pulseValues.clear();
                                           // String data[] = string.split(":");
                                            //for (int i = 0; i < data.length; i++)
                                               // pulseValues.add(data[i]);
                                            textView2.append(string+"asta e puls");
                                       // for (int i = 0; i < pulseValues.size(); i++)
                                           // textView2.append(pulseValues.get(i).toString());
                                       // if(x>10000)
                                           // x=0;
                                    }*/
                                    String sToOut = "";
                                    String[] ss = string.split("d");

                                    for (String s : ss){
                                        //System.out.println("|" + s + "|");
                                        if(s.startsWith("s") && s.endsWith("f")){
                                            sToOut = s;
                                        }
                                    }

                                    String[] vals = sToOut.split(":");
                                    ssd.setHumidity(Double.parseDouble(vals[1]));
                                    ssd.setTemperature(Double.parseDouble(vals[2]));
                                    ssd.setPulse(Double.parseDouble(vals[3]));

                                    System.out.println("Hum: " + ssd.getHumidity().toString());
                                    System.out.println("Temp: " + ssd.getTemperature().toString());
                                    System.out.println("Pulse: " + ssd.getPulse().toString());

                                    Call<SensorDataResponse> call = ApiUtil.getServiceClass().postSensorData(pacientId, ssd);

                                    call.enqueue(new Callback<SensorDataResponse>() {
                                        @Override
                                        public void onResponse(Call<SensorDataResponse> call, Response<SensorDataResponse> response) {
                                            if(response.body() != null){
                                                System.out.println("Sent data");
                                            }
                                        }

                                        @Override
                                        public void onFailure(Call<SensorDataResponse> call, Throwable t) {
                                            //Toast.makeText(getApplicationContext(), "Error", Toast.LENGTH_SHORT).show();
                                        }
                                    });

                                }
                            }, 1000);
                        }

                    } catch (IOException ex) {
                        stopThread = true;
                    }

                }
            }
        });
        thread.start();
    }
    public  boolean isInternetConnection()
    {
        boolean connected = false;
        ConnectivityManager connectivityManager = (ConnectivityManager)getSystemService(Context.CONNECTIVITY_SERVICE);
        if(connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_MOBILE).getState() == NetworkInfo.State.CONNECTED ||
                connectivityManager.getNetworkInfo(ConnectivityManager.TYPE_WIFI).getState() == NetworkInfo.State.CONNECTED) {
            connected = true;
        }
        else
            connected = false;
        return connected;
    }

    public void checkLogInData(View v){

        //textView2.setText("intra");
        String user="pro";
        String password="ip";
        EditText userView = (EditText) findViewById(R.id.actEditTextEmail);
        EditText passView = (EditText) findViewById(R.id.actEditTextPassword);
        //user=postList.get(1).getEmail();
        //password=postList.get(1).getUserName();
        String email = userView.getText().toString();
        String pass = passView.getText().toString();
        Call<LoginResponse> call = ApiUtil.getServiceClass().userLogin(new LoginRequest(email, pass));

        call.enqueue(new Callback<LoginResponse>() {
            @Override
            public void onResponse(Call<LoginResponse> call, Response<LoginResponse> response) {
                response.body();
                loginResponse = response.body();
                if(loginResponse != null){
                    check = true;
                    pacientId = loginResponse.getUser().getId();
                    Toast.makeText(getApplicationContext(), "Login Sucessfull", Toast.LENGTH_SHORT).show();
                }
                else {
                    check = false;
                }

                if(check) {
                    Intent intent = new Intent(getApplicationContext(), MainActivity.class);
                    startActivity(intent);
                }
                else
                    Toast.makeText(getApplicationContext(), "incorrect user or password!", Toast.LENGTH_SHORT).show();

            }

            @Override
            public void onFailure(Call<LoginResponse> call, Throwable t) {
                Toast.makeText(getApplicationContext(), "Error", Toast.LENGTH_SHORT).show();
            }
        });

//        if(user.compareTo(userView.getText().toString())==0 && password.compareTo(passView.getText().toString())==0) {
//            check = true;
//        }

    }
}

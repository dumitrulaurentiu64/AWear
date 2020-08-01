package com.example.awearapp;

import android.app.NotificationChannel;
import android.app.NotificationManager;
import android.app.PendingIntent;
import android.content.Context;
import android.content.Intent;
import android.media.RingtoneManager;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.support.v4.app.NotificationCompat;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.CheckBox;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;
import java.io.BufferedReader;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import static android.content.Context.MODE_PRIVATE;

public class Recommendation extends Fragment {
    View view;
    public String recommendation="hello";
    public static final String FILE_NAME = "recommendations.txt";
    TextView rowTextView;
    public static StringBuilder builder;
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        view=inflater.inflate(R.layout.fragment_recommendation, container, false);
        pulseNotification();
        final LinearLayout lLayout = (LinearLayout)view.findViewById(R.id.linearLayout);
        int i=0;
        if(getRecommendation()) {
            i++;
             rowTextView = new TextView(getContext());
            final CheckBox checkBox=new CheckBox(getContext());
            rowTextView.setText(recommendation);
            rowTextView.setId(i);
            checkBox.setId(i);
            lLayout.addView(rowTextView);
            lLayout.addView(checkBox);
           checkBox.setOnClickListener(new View.OnClickListener() {
               @Override
               public void onClick(View v) {
                   lLayout.removeView(checkBox);
                   lLayout.removeView(rowTextView);
               }
           });
        }
        save();
        try {
            load();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return view;
    }
public boolean getRecommendation(){
        boolean receiveRecommendation=true;
        if(receiveRecommendation)
        {
            //recommendation= ce primesti tu din cloud
        }
        return  receiveRecommendation;
}
public void save(){
    FileOutputStream fos = null;
    try {
        fos= getContext().openFileOutput(FILE_NAME,MODE_PRIVATE);
        fos.write(recommendation.getBytes());
        Toast.makeText(getContext(),"saved to"+getContext().getFilesDir()+ "/"+FILE_NAME,Toast.LENGTH_LONG).show();
    } catch (IOException e) {
        e.printStackTrace();
    }
    finally {
        if(fos!=null){
            try {
                fos.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }
}
public void load() throws IOException {
    FileInputStream fis=null;
    try {
        fis=getContext().openFileInput(FILE_NAME);
    } catch (FileNotFoundException e) {
        e.printStackTrace();
    }
    InputStreamReader reader =new InputStreamReader(fis);
    BufferedReader bufferedReader=new BufferedReader(reader);
    builder=new StringBuilder();
    String text;
    while((text=bufferedReader.readLine())!=null){
        builder.append(text).append("\n") ;
    }
    if(fis!=null)
        fis.close();
}
    public void pulseNotification(){
        int i;
        for(i=0;i< LogInActivity.pulseValues.size();i++)
        {
            int value=Integer.parseInt(LogInActivity.pulseValues.get(i).toString());
            if(value>=120)
            {
                Intent intent = new Intent(getContext(), Recommendation.class);
                intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                PendingIntent pendingIntent = PendingIntent.getActivity(getContext(), 0 /* Request code */, intent,
                        PendingIntent.FLAG_ONE_SHOT);
                String channelId = "pulse Notification";
                Uri defaultSoundUri = RingtoneManager.getDefaultUri(RingtoneManager.TYPE_NOTIFICATION);
                NotificationCompat.Builder notificationBuilder =
                        new NotificationCompat.Builder(getContext(), channelId)
                                .setSmallIcon(R.drawable.doctor)
                                .setContentTitle("Warning!Pulse="+value)
                                .setContentText("Your pulse is going crazy!")
                                .setAutoCancel(true)
                                .setSound(defaultSoundUri)
                                .setContentIntent(pendingIntent);
                NotificationManager notificationManager =
                        (NotificationManager) getActivity().getSystemService(Context.NOTIFICATION_SERVICE);
                // Since android Oreo notification channel is needed.
                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.O) {
                    NotificationChannel channel = new NotificationChannel(channelId,
                            "Channel 1",
                            NotificationManager.IMPORTANCE_DEFAULT);
                    notificationManager.createNotificationChannel(channel);
                }
                notificationManager.notify(0 /* ID of notification */, notificationBuilder.build());
            }
        }

    }

}

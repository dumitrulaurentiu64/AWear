package com.example.awearapp;

import android.graphics.Color;
import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import com.example.awearapp.Models.SensorData;
import com.github.mikephil.charting.charts.LineChart;
import com.github.mikephil.charting.data.Entry;
import com.github.mikephil.charting.data.LineData;
import com.github.mikephil.charting.data.LineDataSet;
import com.github.mikephil.charting.interfaces.datasets.ILineDataSet;

import java.util.ArrayList;

public class Monitoring extends Fragment  {
    @Nullable
    public View view;
    public static SensorData s = LogInActivity.ssd;
    public LineChart ecgChart1 ;
    public LineChart pulseChart ;
    public TextView temp,hum;
    public int [] ecgHCValues={400,400,400,400,400,400,400,400,404,408,411,416,419,425,430,433,437,432,428,424,419,414,410,405,400,400,400,402,401,401,401,400,390,380,370,360,350,340,330,400,430,460,490,520,550,580,610,640,670,700,730,760,800,665,630,595,560,525,490,455,420,385,350,325,300,320,340,360,380,401,400,401,400,400,405,410,416,421,425,431,435,440,417,406,400,400,401,399};
    public static final String TAG="Monitoring";
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        view=inflater.inflate(R.layout.fragment_monitoring, container, false);

        temp=(TextView) view.findViewById((R.id.tempText));
        hum=(TextView) view.findViewById((R.id.humText));
        temp.setText( LogInActivity.ssd.getTemperature().toString());
        hum.setText(LogInActivity.ssd.getHumidity().toString());
        ecgChart1=(LineChart) view.findViewById(R.id.ecgChartView);
        ecgChart1.setDragEnabled(true);
        ecgChart1.setScaleEnabled(false);
        ArrayList<Entry> ecgValues=new ArrayList<>();
        pulseChart=(LineChart) view.findViewById(R.id.pulseChartView);
        pulseChart.setDragEnabled(true);
        pulseChart.setScaleEnabled(false);
///trebuie puse in login datele in arrayuri si trebuie sa fie de tipul entry
        ArrayList<Entry> pulseValues=new ArrayList<>();

        for(int i=0;i<ecgHCValues.length;i++)//forul asta tot in login
        {
            ecgValues.add(new Entry(i*285, ecgHCValues[i]));
        }
        LineDataSet dataSet1=new LineDataSet(ecgValues,"ECG");
        dataSet1.setFillAlpha(100);
        ArrayList<ILineDataSet> dataSets=new ArrayList<>();
        dataSets.add(dataSet1);
        LineData data = new LineData(dataSets);
        ecgChart1.setData(data);
        dataSet1.setColor(Color.BLUE);
        return  view;
    }
}

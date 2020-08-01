package com.example.awearapp;

import android.os.Bundle;
import android.support.annotation.Nullable;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;
import java.text.SimpleDateFormat;
import java.util.Locale;
import static com.example.awearapp.Recommendation.builder;

public class Calendar extends Fragment {
    View view;
    TextView calendarText;
    Button clearBtn;
    private SimpleDateFormat dateFormat=new SimpleDateFormat("MMMM- yyyy", Locale.getDefault());
    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        view=inflater.inflate(R.layout.fragment_calendar, container, false);
        calendarText=(TextView) view.findViewById(R.id.recomendText);
        clearBtn=(Button) view.findViewById(R.id.clearBtn);
        clearBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                calendarText.setText("");
            }
        });
        calendarText.setText(builder);

        return view;
    }
}

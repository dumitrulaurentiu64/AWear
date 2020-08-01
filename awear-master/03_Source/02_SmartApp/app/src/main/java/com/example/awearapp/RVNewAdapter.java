package com.example.awearapp;

import android.content.Context;
import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.awearapp.Models.Medic;

import java.util.List;

public class RVNewAdapter extends RecyclerView.Adapter<MedicsViewHolder> {
    private Context context;

    private List<Medic> medicObjectList;

    public RVNewAdapter(Context context, List<Medic> medicObjects){
        this.medicObjectList = medicObjects;
    }


    @NonNull
    @Override
    public MedicsViewHolder onCreateViewHolder(@NonNull ViewGroup viewGroup, int i) {
        View view = LayoutInflater.from(viewGroup.getContext()).inflate(R.layout.item_layout, viewGroup, false);
        return new MedicsViewHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull MedicsViewHolder medicViewHolder, int i) {
        Medic medic = medicObjectList.get(i);
        medicViewHolder.id.setText(medic.getId());
        medicViewHolder.username.setText(medic.getUserName());
        medicViewHolder.email.setText(medic.getEmail());
        medicViewHolder.fieldOfPractice.setText(medic.getFieldOfPractice());
    }

    @Override
    public int getItemCount() {
        return medicObjectList.size();
    }
}

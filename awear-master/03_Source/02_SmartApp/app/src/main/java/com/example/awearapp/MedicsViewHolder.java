package com.example.awearapp;

import android.support.annotation.NonNull;
import android.support.v7.widget.RecyclerView;
import android.view.View;
import android.widget.TextView;

public class MedicsViewHolder extends RecyclerView.ViewHolder {

    public TextView id;
    public TextView username;
    public TextView email;
    public TextView fieldOfPractice;

    public MedicsViewHolder(@NonNull View itemView) {
        super(itemView);
        id = (TextView) itemView.findViewById(R.id.medic_id);
        username = (TextView) itemView.findViewById(R.id.medic_username);
        email = (TextView) itemView.findViewById(R.id.medic_email);
        fieldOfPractice = (TextView) itemView.findViewById(R.id.medic_practice);
    }
}

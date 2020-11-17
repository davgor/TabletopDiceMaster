package com.example.tabletopdicemaster.ui.roll;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProvider;

import com.example.tabletopdicemaster.R;

public class RollFragment extends Fragment {

    private RollViewModel rollViewModel;

    public View onCreateView(@NonNull LayoutInflater inflater,
                             ViewGroup container, Bundle savedInstanceState) {
        rollViewModel =
                new ViewModelProvider(this).get(RollViewModel.class);
        View root = inflater.inflate(R.layout.fragment_roll, container, false);

        return root;
    }
}
package com.example.tabletopdicemaster.ui.roll;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

public class RollViewModel extends ViewModel {

    private MutableLiveData<String> mText;

    public RollViewModel() {
        mText = new MutableLiveData<>();
        mText.setValue("This is roll fragment");
    }

    public LiveData<String> getText() {
        return mText;
    }
}
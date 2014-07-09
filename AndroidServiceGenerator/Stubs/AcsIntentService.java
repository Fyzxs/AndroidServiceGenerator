package com.laskon.android.stubs;

import android.app.IntentService;

public abstract class AcsIntentService extends IntentService{

    protected abstract void initActionMethods() throws NoSuchMethodException;
}

package com.laskon.android.stubs;

import com.androidcoreservices.messaging.broadcast.WtLocalBroadcastManager;

final public class LocalBroadcastRedirector {

    private final BroadcastReceiver _localBroadcastReceiver;
    private final Class<? extends ContextWrapper> _clazz;
    private final String _className;

    public LocalBroadcastRedirector(final Class<? extends ContextWrapper> clazz) {
        if (clazz == null) {
            throw new IllegalArgumentException("clazz cannot be null");
        }

        _clazz = clazz;
        _className = clazz.getSimpleName();

        _localBroadcastReceiver = new BroadcastReceiver() {

            @Override
            public void onReceive(final Context context, final Intent intent) {
                intent.setComponent(new ComponentName(context, clazz));
                context.startService(intent);
            }
        };
    }

    public void registerLocalBroadcastReceiver(final IntentFilter filter) {
        if (_localBroadcastReceiver == null || filter == null) {
            return;
        }

        unregister();
        WrappingLocalBroadcastManager.instance.registerReceiver(_localBroadcastReceiver, filter);
    }

    public void unregisterLocalBroadcastReceiver() {
        unregister();
    }

    private void unregister() {
        if (_localBroadcastReceiver == null) {
            return;
        }

        WrappingLocalBroadcastManager.instance.unregisterReceiver(_localBroadcastReceiver);
    }
}

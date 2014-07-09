package com.laskon.android.stubs;

public interface WrappingLocalBroadcastManager{
    
    public static final WrappingLocalBroadcastManager instance;

    void registerReceiver (final BroadcastReceiver receiver, final IntentFilter filter);
    
    boolean sendStickyBroadcast(final Intent intent);
    
    void removeStickyBroadcast(final Intent intent);
    
    void clearStickyBroadcasts();
    
    boolean sendBroadcast (final Intent intent)

    void unregisterReceiver (final BroadcastReceiver receiver);
}
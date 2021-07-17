using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_ANDROID
using Unity.Notifications.Android;
#endif

public class AndroidNotificationHandler : MonoBehaviour
{
#if UNITY_ANDROID
    private const string channelId = "notification_chaneel";
    public void ScheduleNotification(DateTime dateTime){
        AndroidNotificationChannel notificationChannel = new AndroidNotificationChannel{
            Id = channelId,
            Name = "Notification Channel",
            Description= "Description",
            Importance = Importance.Default
        };

        AndroidNotificationCenter.RegisterNotificationChannel(notificationChannel);
        AndroidNotification notification = new AndroidNotification{
            Title="Asteroid Avoid - We missed you!",
            Text="Your ship is waiting, come back to play!",
            SmallIcon="default",
            LargeIcon="default",
            FireTime=dateTime
        };

        AndroidNotificationCenter.SendNotification(notification, channelId);
    }
    #endif
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_IOS
using Unity.Notifications.iOS;
#endif

public class iOSNotificationHandler : MonoBehaviour
{
#if UNITY_IOS
    public void ScheduleNotification(int minute){
        iOSNotification notification = new iOSNotification{
            Title="Asteroid Avoid - We missed you!",
            Subtitle="Your ship is waiting, come back to play!",
            Body="Your ship is waiting, come back to play!",
            ShowInForeground=true,
            ForegroundPresentationOption = (PresentationOption.Alert | PresentationOption.Sound),
            CategoryIdentifier = "category_a",
            ThreadIdentifier = "thread1",
            Trigger = new iOSNotificationTimeIntervalTrigger{
                TimeInterval = new System.TimeSpan(0,minute,0),
                Repeats = false
            }
        };

        iOSNotificationCenter.ScheduleNotification(notification);
    }


#endif


}

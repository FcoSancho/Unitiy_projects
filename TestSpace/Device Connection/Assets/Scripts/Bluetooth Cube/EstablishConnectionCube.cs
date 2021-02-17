using UnityEngine;
#if ENABLE_WINMD_SUPPORT
using Windows.Devices.Bluetooth.Advertisement;
#endif

public class EstablishConnectionCube : MonoBehaviour {
#if ENABLE_WINMD_SUPPORT

    private readonly BluetoothLEAdvertisementWatcher mainBWatcher = new BluetoothLEAdvertisementWatcher {ScanningMode = BluetoothLEScanningMode.Active};
    private bool listeningToDevice => mainBWatcher.Status == BluetoothLEAdvertisementWatcherStatus.Started;

    private void Start() {
        Application.OpenURL("yes");
        mainBWatcher.Received += watcherReceived;
        mainBWatcher.Stopped += watcherStopped;
    }

    private void watcherReceived(BluetoothLEAdvertisementWatcher yes, BluetoothLEAdvertisementReceivedEventArgs no) {}

    private void watcherStopped(BluetoothLEAdvertisementWatcher yes, BluetoothLEAdvertisementWatcherStoppedEventArgs no) {}

#endif
}

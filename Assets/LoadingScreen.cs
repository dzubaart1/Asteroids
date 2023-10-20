using Core;
using Platform;
using Services;
using Spawners;
using UnityEngine;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private Button _hardModeBtn;
    [SerializeField] private Button _easyModeBtn;

    private void Awake()
    {
        _hardModeBtn.onClick.AddListener(OnHardBtnClick);
        _easyModeBtn.onClick.AddListener(OnEasyBtnClick);
    }

    private void OnHardBtnClick()
    {
        Engine.GetService<FactoryService>().ChangeFactory(new HardModeFactory());
        Engine.GetService<SceneService>().LoadScene(1);
    }
    
    private void OnEasyBtnClick()
    {
        Engine.GetService<FactoryService>().ChangeFactory(new EasyModeFactory());
        Engine.GetService<SceneService>().LoadScene(1);
    }
}

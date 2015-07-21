// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      Mono Runtime Version: 2.0.50727.1433
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace uFrame.ExampleProject {
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using uFrame.Kernel;
    using uFrame.MVVM;
    using uFrame.MVVM.Services;
    using uFrame.MVVM.Bindings;
    using uFrame.Serialization;
    using UniRx;
    using UnityEngine;
    using uFrame.ExampleProject;
    
    
    public class MainMenuRootViewBase : uFrame.MVVM.ViewBase {
        
        [UnityEngine.SerializeField()]
        [UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public Type _CurrentScreenType;
        
        [UFToggleGroup("Screens")]
        [UnityEngine.HideInInspector()]
        public bool _BindScreens = true;
        
        [UFGroup("Screens")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_Screensparent")]
        protected UnityEngine.Transform _ScreensParent;
        
        [UFGroup("Screens")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_ScreensviewFirst")]
        protected bool _ScreensViewFirst;
        
        public override string DefaultIdentifier {
            get {
                return "MainMenuRoot";
            }
        }
        
        public override System.Type ViewModelType {
            get {
                return typeof(MainMenuRootViewModel);
            }
        }
        
        public MainMenuRootViewModel MainMenuRoot {
            get {
                return (MainMenuRootViewModel)ViewModelObject;
            }
        }
        
        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model) {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as MainMenuRootViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
            var mainmenurootview = ((MainMenuRootViewModel)model);
            mainmenurootview.CurrentScreenType = this._CurrentScreenType;
        }
        
        public override void Bind() {
            base.Bind();
            // Use this.MainMenuRoot to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.
            if (_BindScreens) {
                this.BindToViewCollection(this.MainMenuRoot.Screens, this.ScreensCreateView, this.ScreensAdded, this.ScreensRemoved, _ScreensParent, _ScreensViewFirst);
            }
        }
        
        public virtual uFrame.MVVM.ViewBase ScreensCreateView(uFrame.MVVM.ViewModel viewModel) {
            return InstantiateView(viewModel);
        }
        
        public virtual void ScreensAdded(uFrame.MVVM.ViewBase view) {
        }
        
        public virtual void ScreensRemoved(uFrame.MVVM.ViewBase view) {
        }
    }
    
    public class SubScreenViewBase : uFrame.MVVM.ViewBase {
        
        [UnityEngine.SerializeField()]
        [UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public Boolean _IsActive;
        
        [UFToggleGroup("IsActive")]
        [UnityEngine.HideInInspector()]
        public bool _BindIsActive = true;
        
        [UFGroup("IsActive")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_IsActiveonlyWhenChanged")]
        protected bool _IsActiveOnlyWhenChanged;
        
        [UFToggleGroup("Close")]
        [UnityEngine.HideInInspector()]
        public bool _BindClose = true;
        
        [UFGroup("Close")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_Closebutton")]
        protected UnityEngine.UI.Button _CloseButton;
        
        public override string DefaultIdentifier {
            get {
                return base.DefaultIdentifier;
            }
        }
        
        public override System.Type ViewModelType {
            get {
                return typeof(SubScreenViewModel);
            }
        }
        
        public SubScreenViewModel SubScreen {
            get {
                return (SubScreenViewModel)ViewModelObject;
            }
        }
        
        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model) {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as SubScreenViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
            var subscreenview = ((SubScreenViewModel)model);
            subscreenview.IsActive = this._IsActive;
        }
        
        public override void Bind() {
            base.Bind();
            // Use this.SubScreen to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.
            if (_BindIsActive) {
                this.BindProperty(this.SubScreen.IsActiveProperty, this.IsActiveChanged, _IsActiveOnlyWhenChanged);
            }
            if (_BindClose) {
                this.BindButtonToCommand(_CloseButton, this.SubScreen.Close);
            }
        }
        
        public virtual void IsActiveChanged(Boolean arg1) {
        }
        
        public virtual void ExecuteClose() {
            SubScreen.Close.OnNext(new CloseCommand() { Sender = SubScreen });
        }
        
        public virtual void ExecuteClose(CloseCommand command) {
            command.Sender = SubScreen;
            SubScreen.Close.OnNext(command);
        }
    }
    
    public class LoginScreenViewBase : SubScreenView {
        
        [UnityEngine.SerializeField()]
        [UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public String _Username;
        
        [UnityEngine.SerializeField()]
        [UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public String _Password;
        
        [UFToggleGroup("Login")]
        [UnityEngine.HideInInspector()]
        public bool _BindLogin = true;
        
        [UFGroup("Login")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_Loginbutton")]
        protected UnityEngine.UI.Button _LoginButton;
        
        [UFToggleGroup("Password")]
        [UnityEngine.HideInInspector()]
        public bool _BindPassword = true;
        
        [UFGroup("Password")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_Passwordinput")]
        protected UnityEngine.UI.InputField _PasswordInput;
        
        [UFToggleGroup("Username")]
        [UnityEngine.HideInInspector()]
        public bool _BindUsername = true;
        
        [UFGroup("Username")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_Usernameinput")]
        protected UnityEngine.UI.InputField _UsernameInput;
        
        public override string DefaultIdentifier {
            get {
                return base.DefaultIdentifier;
            }
        }
        
        public override System.Type ViewModelType {
            get {
                return typeof(LoginScreenViewModel);
            }
        }
        
        public LoginScreenViewModel LoginScreen {
            get {
                return (LoginScreenViewModel)ViewModelObject;
            }
        }
        
        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model) {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as LoginScreenViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
            var loginscreenview = ((LoginScreenViewModel)model);
            loginscreenview.Username = this._Username;
            loginscreenview.Password = this._Password;
        }
        
        public override void Bind() {
            base.Bind();
            // Use this.LoginScreen to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.
            if (_BindLogin) {
                this.BindButtonToCommand(_LoginButton, this.LoginScreen.Login);
            }
            if (_BindPassword) {
                this.BindInputFieldToProperty(_PasswordInput, this.LoginScreen.PasswordProperty);
            }
            if (_BindUsername) {
                this.BindInputFieldToProperty(_UsernameInput, this.LoginScreen.UsernameProperty);
            }
        }
        
        public virtual void ExecuteLogin() {
            LoginScreen.Login.OnNext(new LoginCommand() { Sender = LoginScreen });
        }
        
        public virtual void ExecuteLogin(LoginCommand command) {
            command.Sender = LoginScreen;
            LoginScreen.Login.OnNext(command);
        }
    }
    
    public class LevelSelectScreenViewBase : SubScreenView {
        
        [UFToggleGroup("AvailableLevels")]
        [UnityEngine.HideInInspector()]
        public bool _BindAvailableLevels = true;
        
        public override string DefaultIdentifier {
            get {
                return base.DefaultIdentifier;
            }
        }
        
        public override System.Type ViewModelType {
            get {
                return typeof(LevelSelectScreenViewModel);
            }
        }
        
        public LevelSelectScreenViewModel LevelSelectScreen {
            get {
                return (LevelSelectScreenViewModel)ViewModelObject;
            }
        }
        
        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model) {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as LevelSelectScreenViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
        }
        
        public override void Bind() {
            base.Bind();
            // Use this.LevelSelectScreen to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.
            if (_BindAvailableLevels) {
                this.BindCollection(this.LevelSelectScreen.AvailableLevels, this.AvailableLevelsOnAdd, this.AvailableLevelsOnRemove);
            }
        }
        
        public virtual void AvailableLevelsOnAdd(LevelDescriptor arg1) {
        }
        
        public virtual void AvailableLevelsOnRemove(LevelDescriptor arg1) {
        }
        
        public virtual void ExecuteSelectLevel(SelectLevelCommand command) {
            command.Sender = LevelSelectScreen;
            LevelSelectScreen.SelectLevel.OnNext(command);
        }
        
        public virtual void ExecuteSelectLevel(LevelDescriptor arg) {
            LevelSelectScreen.SelectLevel.OnNext(new SelectLevelCommand() { Sender = LevelSelectScreen, Argument = arg });
        }
    }
    
    public class SettingsScreenViewBase : SubScreenView {
        
        [UnityEngine.SerializeField()]
        [UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public ResolutionInformation _Resolution;
        
        [UnityEngine.SerializeField()]
        [UFGroup("View Model Properties")]
        [UnityEngine.HideInInspector()]
        public Single _Volume;
        
        [UFToggleGroup("Volume")]
        [UnityEngine.HideInInspector()]
        public bool _BindVolume = true;
        
        [UFGroup("Volume")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_Volumeslider")]
        protected UnityEngine.UI.Slider _VolumeSlider;
        
        [UFToggleGroup("Resolution")]
        [UnityEngine.HideInInspector()]
        public bool _BindResolution = true;
        
        [UFGroup("Resolution")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_ResolutiononlyWhenChanged")]
        protected bool _ResolutionOnlyWhenChanged;
        
        [UFToggleGroup("Apply")]
        [UnityEngine.HideInInspector()]
        public bool _BindApply = true;
        
        [UFGroup("Apply")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_Applybutton")]
        protected UnityEngine.UI.Button _ApplyButton;
        
        [UFToggleGroup("Default")]
        [UnityEngine.HideInInspector()]
        public bool _BindDefault = true;
        
        [UFGroup("Default")]
        [UnityEngine.SerializeField()]
        [UnityEngine.HideInInspector()]
        [UnityEngine.Serialization.FormerlySerializedAsAttribute("_Defaultbutton")]
        protected UnityEngine.UI.Button _DefaultButton;
        
        public override string DefaultIdentifier {
            get {
                return base.DefaultIdentifier;
            }
        }
        
        public override System.Type ViewModelType {
            get {
                return typeof(SettingsScreenViewModel);
            }
        }
        
        public SettingsScreenViewModel SettingsScreen {
            get {
                return (SettingsScreenViewModel)ViewModelObject;
            }
        }
        
        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model) {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as SettingsScreenViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
            var settingsscreenview = ((SettingsScreenViewModel)model);
            settingsscreenview.Resolution = this._Resolution;
            settingsscreenview.Volume = this._Volume;
        }
        
        public override void Bind() {
            base.Bind();
            // Use this.SettingsScreen to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.
            if (_BindVolume) {
                this.BindSliderToProperty(_VolumeSlider, this.SettingsScreen.VolumeProperty);
            }
            if (_BindResolution) {
                this.BindProperty(this.SettingsScreen.ResolutionProperty, this.ResolutionChanged, _ResolutionOnlyWhenChanged);
            }
            if (_BindApply) {
                this.BindButtonToCommand(_ApplyButton, this.SettingsScreen.Apply);
            }
            if (_BindDefault) {
                this.BindButtonToCommand(_DefaultButton, this.SettingsScreen.Default);
            }
        }
        
        public virtual void ResolutionChanged(ResolutionInformation arg1) {
        }
        
        public virtual void ExecuteApply() {
            SettingsScreen.Apply.OnNext(new ApplyCommand() { Sender = SettingsScreen });
        }
        
        public virtual void ExecuteDefault() {
            SettingsScreen.Default.OnNext(new DefaultCommand() { Sender = SettingsScreen });
        }
        
        public virtual void ExecuteApply(ApplyCommand command) {
            command.Sender = SettingsScreen;
            SettingsScreen.Apply.OnNext(command);
        }
        
        public virtual void ExecuteDefault(DefaultCommand command) {
            command.Sender = SettingsScreen;
            SettingsScreen.Default.OnNext(command);
        }
    }
    
    public class MenuScreenViewBase : SubScreenView {
        
        public override string DefaultIdentifier {
            get {
                return base.DefaultIdentifier;
            }
        }
        
        public override System.Type ViewModelType {
            get {
                return typeof(MenuScreenViewModel);
            }
        }
        
        public MenuScreenViewModel MenuScreen {
            get {
                return (MenuScreenViewModel)ViewModelObject;
            }
        }
        
        protected override void InitializeViewModel(uFrame.MVVM.ViewModel model) {
            base.InitializeViewModel(model);
            // NOTE: this method is only invoked if the 'Initialize ViewModel' is checked in the inspector.
            // var vm = model as MenuScreenViewModel;
            // This method is invoked when applying the data from the inspector to the viewmodel.  Add any view-specific customizations here.
        }
        
        public override void Bind() {
            base.Bind();
            // Use this.MenuScreen to access the viewmodel.
            // Use this method to subscribe to the view-model.
            // Any designer bindings are created in the base implementation.
        }
    }
}

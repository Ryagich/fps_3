using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using NeoFPS.Constants;
using YG;

namespace NeoFPS.Samples
{
    public class MultiInputKeyBinding : MultiInputButtonGroup
    {
        private EventSystem m_EventSystem = null;
        private Text m_PrimaryText = null;
        private Text m_SecondaryText = null;

        public FpsInputButton button { get; private set; }

        private Text primaryText
        {
            get
            {
                if (m_PrimaryText == null && buttons.Length > 0 && buttons[0].rect != null)
                    m_PrimaryText = buttons[0].rect.GetComponentInChildren<Text>();
                return m_PrimaryText;
            }
        }

        private Text secondaryText
        {
            get
            {
                if (m_SecondaryText == null && buttons.Length > 1 && buttons[1].rect != null)
                    m_SecondaryText = buttons[1].rect.GetComponentInChildren<Text>();
                return m_SecondaryText;
            }
        }

        private KeyCode m_PrimaryKey = KeyCode.None;

        public KeyCode primary
        {
            get { return m_PrimaryKey; }
            set
            {
                m_PrimaryKey = value;
                if (primaryText != null)
                {
                    if (value == KeyCode.None)
                        primaryText.text = string.Empty;
                    else
                        primaryText.text = value.ToString();
                    if (value == KeyCode.Space)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "Пробел";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "boşluk";
                    }

                    if (value == KeyCode.Alpha0 || value == KeyCode.Keypad0)
                    {
                        primaryText.text = "0";
                    }

                    if (value == KeyCode.Alpha1 || value == KeyCode.Keypad1)
                    {
                        primaryText.text = "1";
                    }

                    if (value == KeyCode.Alpha2 || value == KeyCode.Keypad2)
                    {
                        primaryText.text = "2";
                    }

                    if (value == KeyCode.Alpha3 || value == KeyCode.Keypad3)
                    {
                        primaryText.text = "3";
                    }

                    if (value == KeyCode.Alpha4 || value == KeyCode.Keypad4)
                    {
                        primaryText.text = "4";
                    }

                    if (value == KeyCode.Alpha5 || value == KeyCode.Keypad5)
                    {
                        primaryText.text = "5";
                    }

                    if (value == KeyCode.Alpha6 || value == KeyCode.Keypad6)
                    {
                        primaryText.text = "6";
                    }

                    if (value == KeyCode.Alpha7 || value == KeyCode.Keypad7)
                    {
                        primaryText.text = "7";
                    }

                    if (value == KeyCode.Alpha8 || value == KeyCode.Keypad8)
                    {
                        primaryText.text = "8";
                    }

                    if (value == KeyCode.Alpha9 || value == KeyCode.Keypad9)
                    {
                        primaryText.text = "9";
                    }

                    if (value == KeyCode.LeftShift)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "Левый Shift";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "Sol Shift";
                    }

                    if (value == KeyCode.RightShift)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "Правый Shift";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "Sağ Shift";
                    }

                    if (value == KeyCode.LeftControl)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "Левый Ctrl";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "Sol Ctrl";
                    }

                    if (value == KeyCode.RightControl)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "Правый Ctrl";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "Sağ Ctrl";
                    }

                    if (value == KeyCode.LeftAlt)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "Левый Alt";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "Sol Alt";
                    }

                    if (value == KeyCode.RightAlt)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "Правый Alt";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "Sağ Alt";
                    }

                    if (value == KeyCode.Minus)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "Минус";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "Eksi";
                    }

                    if (value == KeyCode.Plus)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "Плюс";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "Artı";
                    }

                    if (value == KeyCode.LeftBracket)
                    {
                        primaryText.text = "[";
                    }

                    if (value == KeyCode.RightBracket)
                    {
                        primaryText.text = "]";
                    }

                    if (value == KeyCode.Semicolon)
                    {
                        primaryText.text = ";";
                    }

                    if (value == KeyCode.Quote)
                    {
                        primaryText.text = "'";
                    }

                    if (value == KeyCode.Comma)
                    {
                        primaryText.text = ",";
                    }

                    if (value == KeyCode.Period)
                    {
                        primaryText.text = ".";
                    }

                    if (value == KeyCode.Slash)
                    {
                        primaryText.text = "/";
                    }

                    if (value == KeyCode.Backslash)
                    {
                        primaryText.text = "\\";
                    }
                    if (value == KeyCode.Mouse0)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "ЛКМ";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "Sol Fare Tuşu";
                        if (YandexGame.EnvironmentData.language == "en")
                            primaryText.text = "LMB";
                    }
                    if (value == KeyCode.Mouse1)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "ПКМ";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "Sağ Fare Tuşu";
                        if (YandexGame.EnvironmentData.language == "en")
                            primaryText.text = "RMB";
                    }
                    if (value == KeyCode.Mouse2)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            primaryText.text = "Колесико мыши";
                        if (YandexGame.EnvironmentData.language == "tr")
                            primaryText.text = "Fare tekerleği";
                        if (YandexGame.EnvironmentData.language == "en")
                            primaryText.text = "Mouse wheel";
                    }
                }
            }
        }

        private KeyCode m_SecondaryKey = KeyCode.None;

        public KeyCode secondary
        {
            get { return m_SecondaryKey; }
            set
            {
                m_SecondaryKey = value;
                if (secondaryText != null)
                {
                    if (value == KeyCode.None)
                        secondaryText.text = string.Empty;
                    else
                        secondaryText.text = value.ToString();
                    if (value == KeyCode.Space)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "Пробел";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "boşluk";
                    }

                    if (value == KeyCode.Alpha0 || value == KeyCode.Keypad0)
                    {
                        secondaryText.text = "0";
                    }

                    if (value == KeyCode.Alpha1 || value == KeyCode.Keypad1)
                    {
                        secondaryText.text = "1";
                    }

                    if (value == KeyCode.Alpha2 || value == KeyCode.Keypad2)
                    {
                        secondaryText.text = "2";
                    }

                    if (value == KeyCode.Alpha3 || value == KeyCode.Keypad3)
                    {
                        secondaryText.text = "3";
                    }

                    if (value == KeyCode.Alpha4 || value == KeyCode.Keypad4)
                    {
                        secondaryText.text = "4";
                    }

                    if (value == KeyCode.Alpha5 || value == KeyCode.Keypad5)
                    {
                        secondaryText.text = "5";
                    }

                    if (value == KeyCode.Alpha6 || value == KeyCode.Keypad6)
                    {
                        secondaryText.text = "6";
                    }

                    if (value == KeyCode.Alpha7 || value == KeyCode.Keypad7)
                    {
                        secondaryText.text = "7";
                    }

                    if (value == KeyCode.Alpha8 || value == KeyCode.Keypad8)
                    {
                        secondaryText.text = "8";
                    }

                    if (value == KeyCode.Alpha9 || value == KeyCode.Keypad9)
                    {
                        secondaryText.text = "9";
                    }

                    if (value == KeyCode.LeftShift)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "Левый Shift";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "Sol Shift";
                    }

                    if (value == KeyCode.RightShift)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "Правый Shift";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "Sağ Shift";
                    }

                    if (value == KeyCode.LeftControl)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "Левый Ctrl";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "Sol Ctrl";
                    }

                    if (value == KeyCode.RightControl)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "Правый Ctrl";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "Sağ Ctrl";
                    }

                    if (value == KeyCode.LeftAlt)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "Левый Alt";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "Sol Alt";
                    }

                    if (value == KeyCode.RightAlt)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "Правый Alt";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "Sağ Alt";
                    }

                    if (value == KeyCode.Minus)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "Минус";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "Eksi";
                    }

                    if (value == KeyCode.Plus)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "Плюс";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "Artı";
                    }

                    if (value == KeyCode.LeftBracket)
                    {
                        secondaryText.text = "[";
                    }

                    if (value == KeyCode.RightBracket)
                    {
                        secondaryText.text = "]";
                    }

                    if (value == KeyCode.Semicolon)
                    {
                        secondaryText.text = ";";
                    }

                    if (value == KeyCode.Quote)
                    {
                        secondaryText.text = "'";
                    }

                    if (value == KeyCode.Comma)
                    {
                        secondaryText.text = ",";
                    }

                    if (value == KeyCode.Period)
                    {
                        secondaryText.text = ".";
                    }

                    if (value == KeyCode.Slash)
                    {
                        secondaryText.text = "/";
                    }

                    if (value == KeyCode.Backslash)
                    {
                        secondaryText.text = "\\";
                    } //

                    if (value == KeyCode.Mouse0)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "ЛКМ";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "Sol Fare Tuşu";
                        if (YandexGame.EnvironmentData.language == "en")
                            secondaryText.text = "LMB";
                    }
                    if (value == KeyCode.Mouse1)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "ПКМ";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "Sağ Fare Tuşu";
                        if (YandexGame.EnvironmentData.language == "en")
                            secondaryText.text = "RMB";
                    }
                    if (value == KeyCode.Mouse2)
                    {
                        if (YandexGame.EnvironmentData.language == "ru")
                            secondaryText.text = "Колесико мыши";
                        if (YandexGame.EnvironmentData.language == "tr")
                            secondaryText.text = "Fare tekerleği";
                        if (YandexGame.EnvironmentData.language == "en")
                            secondaryText.text = "Mouse wheel";
                    }
                }
            }
        }

        protected override void Awake()
        {
            base.Awake();
            buttons[0].onClick.AddListener(SetPrimaryBinding);
            buttons[1].onClick.AddListener(SetSecondaryBinding);
        }

        public void Initialise(FpsInputButton b, string title, KeyCode b1, KeyCode b2)
        {
            label = title;
            button = b;
            primary = b1;
            secondary = b2;
        }

        public void SetPrimaryBinding()
        {
            primaryText.text = "???";
            m_EventSystem = EventSystem.current;
            m_EventSystem.enabled = false;
            FpsSettings.keyBindings.onRebind += OnRebindInput;
            FpsSettings.keyBindings.RebindInput(button, true);
            PlayAudio(MenuAudio.ClickValid);
        }

        public void SetSecondaryBinding()
        {
            secondaryText.text = "???";
            m_EventSystem = EventSystem.current;
            m_EventSystem.enabled = false;
            FpsSettings.keyBindings.onRebind += OnRebindInput;
            FpsSettings.keyBindings.RebindInput(button, false);
            PlayAudio(MenuAudio.ClickValid);
        }

        void OnRebindInput(FpsInputButton button, bool isPrimary, KeyCode newKey)
        {
            m_EventSystem.enabled = true;
            m_EventSystem.SetSelectedGameObject(gameObject);
            FpsSettings.keyBindings.onRebind -= OnRebindInput;
        }
    }
}
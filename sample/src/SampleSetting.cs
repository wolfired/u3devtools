using System;
using UnityEngine;
using UnityEditor;

namespace u3devtools.sample
{
    /// 多选
    public enum Smn
    {
        CustomNothing = 0,
        Sun = 1 << 0,
        Son = 1 << 1,
        Svn = 1 << 2,
        CustomEverything = ~0,
    }

    /// 单选
    public enum Ssn
    {
        Sun = 1 << 0,
        Son = 1 << 1,
        Svn = 1 << 2,
    }

    [CreateAssetMenu(fileName = "SampleSetting.asset", menuName = "U3Devtools/Sample Setting")]
    public class SampleSetting : ScriptableObject
    {
        public Bounds _bounds;
        public BoundsInt _boundsInt;
        public Color _color;
        public AnimationCurve _animationCurve;
        public int _int = 0;
        public long _long = 0;
        public float _float = 0.0f;
        public double _double = 0.0;
        public string _text = "default text";
        public string _dropdownButton = "DropdownButton - ?";
        public Smn _enumFlagsField = Smn.Sun;
        public Ssn _enumPopup = Ssn.Sun;
        public bool _foldout = false;
        public Gradient _gradient;
        public bool _inspectorTitlebar = false;
        public int _intPopup = 0;
        public int _intSlider = 0;
        public string _labelField = "default text(read only)";
        public int _layerField;
        public int _maskField = 0;
        public float _MinMaxSlider_min = 0.0f;
        public float _MinMaxSlider_max = 1.0f;
        public string _passwordField = "";
        public int _popup = 0;
        public Rect _rectField;
        public RectInt _rectIntField;
        public string _selectableLabel = "default text(read only)";
        public float _slider = 0.0f;
        public string _tagField = "default text";
        public string _textArea = "Text Area";
        public string _textField = "Text Field";
        public bool _toggle = false;
        public bool _toggleLeft = false;
        public Vector2 _vector2Field;
        public Vector2Int _vector2IntField;
        public Vector3 _vector3Field;
        public Vector3Int _vector3IntField;
        public Vector4 _vector4Field;
        public BuildTargetGroup _selectedBuildTargetGroup = BuildTargetGroup.Standalone;
        public bool _foldoutHeaderGroup = true;
        public Vector2 _scrollView;
        public bool _toggleGroup;

        public void OnEnable()
        {
            _layerField = LayerMask.NameToLayer("Default");
        }
    }

    [CustomEditor(typeof(SampleSetting))]
    [CanEditMultipleObjects]
    public class SampleSettingEditor : Editor
    {
        private SerializedProperty _bounds;
        private SerializedProperty _boundsInt;
        private SerializedProperty _color;
        private SerializedProperty _animationCurve;
        public SerializedProperty _int;
        public SerializedProperty _long;
        public SerializedProperty _float;
        public SerializedProperty _double;
        public SerializedProperty _text;
        public SerializedProperty _dropdownButton;
        public SerializedProperty _enumFlagsField;
        public SerializedProperty _enumPopup;
        public SerializedProperty _foldout;
        public SerializedProperty _gradient;
        public SerializedProperty _inspectorTitlebar;
        public SerializedProperty _intPopup;
        public SerializedProperty _intSlider;
        public SerializedProperty _labelField;
        public SerializedProperty _layerField;
        public SerializedProperty _maskField;
        public SerializedProperty _MinMaxSlider_min;
        public SerializedProperty _MinMaxSlider_max;
        public SerializedProperty _passwordField;
        public SerializedProperty _popup;
        public SerializedProperty _rectField;
        public SerializedProperty _rectIntField;
        public SerializedProperty _selectableLabel;
        public SerializedProperty _slider;
        public SerializedProperty _tagField;
        public SerializedProperty _textArea;
        public SerializedProperty _textField;
        public SerializedProperty _toggle;
        public SerializedProperty _toggleLeft;
        public SerializedProperty _vector2Field;
        public SerializedProperty _vector2IntField;
        public SerializedProperty _vector3Field;
        public SerializedProperty _vector3IntField;
        public SerializedProperty _vector4Field;
        public SerializedProperty _selectedBuildTargetGroup;
        public SerializedProperty _foldoutHeaderGroup;
        public SerializedProperty _scrollView;
        public SerializedProperty _toggleGroup;

        public void Awake()
        {
            // Debug.Log("SampleSettingEditor.Awake");

            _bounds = this.serializedObject.FindProperty("_bounds");
            _boundsInt = this.serializedObject.FindProperty("_boundsInt");
            _color = this.serializedObject.FindProperty("_color");
            _animationCurve = this.serializedObject.FindProperty("_animationCurve");
            _int = this.serializedObject.FindProperty("_int");
            _long = this.serializedObject.FindProperty("_long");
            _float = this.serializedObject.FindProperty("_float");
            _double = this.serializedObject.FindProperty("_double");
            _text = this.serializedObject.FindProperty("_text");
            _dropdownButton = this.serializedObject.FindProperty("_dropdownButton");
            _enumFlagsField = this.serializedObject.FindProperty("_enumFlagsField");
            _enumPopup = this.serializedObject.FindProperty("_enumPopup");
            _foldout = this.serializedObject.FindProperty("_foldout");
            _gradient = this.serializedObject.FindProperty("_gradient");
            _inspectorTitlebar = this.serializedObject.FindProperty("_inspectorTitlebar");
            _intPopup = this.serializedObject.FindProperty("_intPopup");
            _intSlider = this.serializedObject.FindProperty("_intSlider");
            _labelField = this.serializedObject.FindProperty("_labelField");
            _layerField = this.serializedObject.FindProperty("_layerField");
            _maskField = this.serializedObject.FindProperty("_maskField");
            _MinMaxSlider_min = this.serializedObject.FindProperty("_MinMaxSlider_min");
            _MinMaxSlider_max = this.serializedObject.FindProperty("_MinMaxSlider_max");
            _passwordField = this.serializedObject.FindProperty("_passwordField");
            _popup = this.serializedObject.FindProperty("_popup");
            _rectField = this.serializedObject.FindProperty("_rectField");
            _rectIntField = this.serializedObject.FindProperty("_rectIntField");
            _selectableLabel = this.serializedObject.FindProperty("_selectableLabel");
            _slider = this.serializedObject.FindProperty("_slider");
            _tagField = this.serializedObject.FindProperty("_tagField");
            _textArea = this.serializedObject.FindProperty("_textArea");
            _textField = this.serializedObject.FindProperty("_textField");
            _toggle = this.serializedObject.FindProperty("_toggle");
            _toggleLeft = this.serializedObject.FindProperty("_toggleLeft");
            _vector2Field = this.serializedObject.FindProperty("_vector2Field");
            _vector2IntField = this.serializedObject.FindProperty("_vector2IntField");
            _vector3Field = this.serializedObject.FindProperty("_vector3Field");
            _vector3IntField = this.serializedObject.FindProperty("_vector3IntField");
            _vector4Field = this.serializedObject.FindProperty("_vector4Field");
            _selectedBuildTargetGroup = this.serializedObject.FindProperty("_selectedBuildTargetGroup");
            _foldoutHeaderGroup = this.serializedObject.FindProperty("_foldoutHeaderGroup");
            _scrollView = this.serializedObject.FindProperty("_scrollView");
            _toggleGroup = this.serializedObject.FindProperty("_toggleGroup");
        }

        public void OnEnable()
        {
            // Debug.Log("SampleSettingEditor.OnEnable");
        }

        public void OnDisable()
        {
            // Debug.Log("SampleSettingEditor.OnDisable");
        }

        public void OnDestroy()
        {
            // Debug.Log("SampleSettingEditor.OnDestroy");
        }

        public override void OnInspectorGUI()
        {
            // Debug.Log("SampleSettingEditor.OnInspectorGUI");

            this.serializedObject.UpdateIfRequiredOrScript();

            _bounds.boundsValue = EditorGUILayout.BoundsField("Bounds", _bounds.boundsValue);
            _boundsInt.boundsIntValue = EditorGUILayout.BoundsIntField("BoundsInt", _boundsInt.boundsIntValue);

            _color.colorValue = EditorGUILayout.ColorField("Color", _color.colorValue);

            _animationCurve.animationCurveValue = EditorGUILayout.CurveField("AnimationCurve", _animationCurve.animationCurveValue);

            {
                _int.intValue = EditorGUILayout.IntField("Int", _int.intValue);
                _int.intValue = EditorGUILayout.DelayedIntField("Delayed Int", _int.intValue);

                _long.longValue = EditorGUILayout.LongField("Long", _long.longValue);

                _float.floatValue = EditorGUILayout.FloatField("Float", _float.floatValue);
                _float.floatValue = EditorGUILayout.DelayedFloatField("Delayed Float", _float.floatValue);

                _double.doubleValue = EditorGUILayout.DoubleField("Double", _double.doubleValue);
                _double.doubleValue = EditorGUILayout.DelayedDoubleField("Delayed Double", _double.doubleValue);

                _text.stringValue = EditorGUILayout.TextField("Text", _text.stringValue);
                _text.stringValue = EditorGUILayout.DelayedTextField("DelayedText", _text.stringValue);
            }


            if (EditorGUILayout.DropdownButton(new GUIContent(_dropdownButton.stringValue), FocusType.Keyboard))
            {
                GenericMenu gm = new GenericMenu();

                foreach (string menu in new string[] { "DropdownButton - Sun", "DropdownButton - Son" })
                {
                    gm.AddItem(new GUIContent(menu), _dropdownButton.stringValue.Equals(menu), delegate (object value)
                    {
                        _dropdownButton.stringValue = value.ToString();

                        if (this.serializedObject.hasModifiedProperties)
                        {
                            this.serializedObject.ApplyModifiedProperties();
                        }
                    }, menu);
                }

                gm.ShowAsContext();
            }

            EditorGUILayout.HelpBox("EditorToolbar TODO", MessageType.Warning);
            EditorGUILayout.HelpBox("EditorToolbarForTarget TODO", MessageType.Warning);

            _enumFlagsField.intValue = Convert.ToInt32(EditorGUILayout.EnumFlagsField("Enum Flags Field", (Smn)_enumFlagsField.intValue));
            _enumPopup.intValue = Convert.ToInt32(EditorGUILayout.EnumPopup("Enum Popup", (Ssn)_enumPopup.intValue));

            _foldout.boolValue = EditorGUILayout.Foldout(_foldout.boolValue, "Foldout");
            if (_foldout.boolValue)
            {
                EditorGUILayout.HelpBox("Foldout is true", MessageType.Info);
            }
            else
            {
                EditorGUILayout.HelpBox("Foldout is false", MessageType.Info);
            }

            EditorGUILayout.HelpBox("GetControlRect TODO", MessageType.Warning);
            EditorGUILayout.HelpBox("GradientField TODO", MessageType.Warning);

            EditorGUILayout.HelpBox("MessageType.None", MessageType.None);
            EditorGUILayout.HelpBox("MessageType.Info", MessageType.Info);
            EditorGUILayout.HelpBox("MessageType.Warning", MessageType.Warning);
            EditorGUILayout.HelpBox("MessageType.Error", MessageType.Error);

            _inspectorTitlebar.boolValue = EditorGUILayout.InspectorTitlebar(_inspectorTitlebar.boolValue, this.target);
            if (_inspectorTitlebar.boolValue)
            {
                EditorGUILayout.HelpBox("InspectorTitlebar is true", MessageType.Info);
            }
            else
            {
                EditorGUILayout.HelpBox("InspectorTitlebar is false", MessageType.Info);
            }

            _intPopup.intValue = EditorGUILayout.IntPopup("Int Popup", _intPopup.intValue, new string[] { "Sun", "Son", "Svn" }, new int[] { 0, 1, 2 });

            _intSlider.intValue = EditorGUILayout.IntSlider("Int Slider", _intSlider.intValue, 0, 255);

            EditorGUILayout.LabelField("Label Field", _labelField.stringValue);

            _layerField.intValue = EditorGUILayout.LayerField("Layer Field", _layerField.intValue);

            _maskField.intValue = EditorGUILayout.MaskField("Mask Field", _maskField.intValue, new string[] { "Sun", "Son", "Svn" });

            float minMaxSlider_min = _MinMaxSlider_min.floatValue;
            float minMaxSlider_max = _MinMaxSlider_max.floatValue;
            EditorGUILayout.MinMaxSlider(ref minMaxSlider_min, ref minMaxSlider_max, 0.0f, 1.0f);
            _MinMaxSlider_min.floatValue = minMaxSlider_min;
            _MinMaxSlider_max.floatValue = minMaxSlider_max;

            EditorGUILayout.HelpBox("ObjectField TODO", MessageType.Warning);

            _passwordField.stringValue = EditorGUILayout.PasswordField("Password Field", _passwordField.stringValue);

            _popup.intValue = EditorGUILayout.Popup("Popup", _popup.intValue, new string[] { "Sun", "Son", "Svn" });

            EditorGUILayout.HelpBox("PrefixLabel TODO", MessageType.Warning);

            EditorGUILayout.HelpBox("PropertyField TODO", MessageType.Warning);

            _rectField.rectValue = EditorGUILayout.RectField("Rect Field", _rectField.rectValue);
            _rectIntField.rectIntValue = EditorGUILayout.RectIntField("Rect Int Field", _rectIntField.rectIntValue);

            EditorGUILayout.SelectableLabel(_selectableLabel.stringValue);

            _slider.floatValue = EditorGUILayout.Slider("Slider", _slider.floatValue, 0.0f, 1.0f);

            EditorGUILayout.Space();

            _tagField.stringValue = EditorGUILayout.TagField("Tag Field", _tagField.stringValue);

            _textArea.stringValue = EditorGUILayout.TextArea(_textArea.stringValue);

            _textField.stringValue = EditorGUILayout.TextField("Text Field", _textField.stringValue);

            _toggle.boolValue = EditorGUILayout.Toggle("Toggle", _toggle.boolValue);

            _toggleLeft.boolValue = EditorGUILayout.ToggleLeft("Toggle Left", _toggleLeft.boolValue);

            _vector2Field.vector2Value = EditorGUILayout.Vector2Field("Vector2 Field", _vector2Field.vector2Value);
            _vector2IntField.vector2IntValue = EditorGUILayout.Vector2IntField("Vector2 Int Field", _vector2IntField.vector2IntValue);
            _vector3Field.vector3Value = EditorGUILayout.Vector3Field("Vector3 Field", _vector3Field.vector3Value);
            _vector3IntField.vector3IntValue = EditorGUILayout.Vector3IntField("Vector3 Int Field", _vector3IntField.vector3IntValue);
            _vector4Field.vector4Value = EditorGUILayout.Vector4Field("Vector4 Field", _vector4Field.vector4Value);

            _selectedBuildTargetGroup.intValue = Convert.ToInt32(EditorGUILayout.BeginBuildTargetSelectionGrouping());
            EditorGUILayout.HelpBox(_selectedBuildTargetGroup.enumDisplayNames[_selectedBuildTargetGroup.enumValueIndex], MessageType.Info);
            EditorGUILayout.EndBuildTargetSelectionGrouping();

            if (EditorGUILayout.BeginFadeGroup(_slider.floatValue))
            {
                EditorGUILayout.HelpBox("Fade Value: " + _slider.floatValue, MessageType.Info);
            }
            EditorGUILayout.EndFadeGroup();

            if (_foldoutHeaderGroup.boolValue = EditorGUILayout.BeginFoldoutHeaderGroup(_foldoutHeaderGroup.boolValue, "FoldoutHeaderGroup", null, delegate (Rect r)
            {
                var menu = new GenericMenu();
                menu.AddItem(new GUIContent("Click me"), true, delegate ()
                {
                    Debug.Log("FoldoutHeaderGroup Click me");
                });
                menu.DropDown(r);
            }))
            {
                EditorGUILayout.HelpBox("FoldoutHeaderGroup", MessageType.Info);
            }

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox("BeginHorizontal HelpBox0", MessageType.Info);
            EditorGUILayout.HelpBox("BeginHorizontal HelpBox1", MessageType.Info);
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginVertical();
            EditorGUILayout.HelpBox("BeginVertical HelpBox0", MessageType.Info);
            EditorGUILayout.HelpBox("BeginVertical HelpBox1", MessageType.Info);
            EditorGUILayout.EndVertical();

            _scrollView.vector2Value = EditorGUILayout.BeginScrollView(_scrollView.vector2Value, GUILayout.Width(256.0f), GUILayout.Height(256.0F));
            _textArea.stringValue = EditorGUILayout.TextArea(_textArea.stringValue);
            EditorGUILayout.EndScrollView();

            _toggleGroup.boolValue = EditorGUILayout.BeginToggleGroup("Toggle Group", _toggleGroup.boolValue);
            _textField.stringValue = EditorGUILayout.TextField("Text Field", _textField.stringValue);
            EditorGUILayout.EndToggleGroup();

            if (this.serializedObject.hasModifiedProperties)
            {
                this.serializedObject.ApplyModifiedProperties();
            }
        }
    }
}

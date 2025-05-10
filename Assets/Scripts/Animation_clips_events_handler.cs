//������ �������������� ������ � ��������� (�������� �� �������� ���������� � ������)
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Sych_scripts
{
    [AddComponentMenu("Sych scripts / Game / Handlers / Animation clips events handler")]
    [DisallowMultipleComponent]
    public class Animation_clips_events_handler : MonoBehaviour
    {
        [Tooltip("������ ��� ���������")]
        [SerializeField]
        Event_class[] Animator_event_array = new Event_class[0];

        /// <summary>
        /// ������������ ����������� ����� �� �����
        /// </summary>
        /// <param name="_event_name">��� ������</param>
        public void Activation_animation_event(string _event_name)
        {
            bool result = false;

            if (Animator_event_array.Length > 0)
            {
                for (int x = 0; x < Animator_event_array.Length; x++)
                {
                    if (Animator_event_array[x].Event_name == _event_name)
                    {
                        Animator_event_array[x].Animation_event.Invoke();
                        result = true;
                        break;
                    }
                }

                if (!result)
                {
                    Debug.LogError("����� � ������  " + _event_name + "  �� ����������!");
                }
            }
            else
            {
                Debug.LogError("���� ������� �� ����� ������!");
            }
        }

    }

    [System.Serializable]
    class Event_class
    {
        [Tooltip("����� ��� ���������")]
        public UnityEvent Animation_event = new UnityEvent();

        public string Event_name = "��� ������";
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FunFun.Optimization
{
    public delegate void FrameLogic();


    public class TimeSlot
    {
        private float timer;
        private int frameTarget;
        private int frameCounter;
        private FrameLogic timeSlotLogic;

        public TimeSlot(FrameLogic timeSlotLogic, int frameTarget)
        {
            this.timeSlotLogic = timeSlotLogic;
            this.frameTarget = frameTarget;
        }

        public void Update()
        {
            if (frameCounter == frameTarget)
            {
                timeSlotLogic();
                frameCounter = 0;
            }


            frameCounter++;
        }
    }


    public class TimeSlotBehaviour : MonoBehaviour
    {

        public static List<TimeSlot> partitions
        {
            get
            {
                if (_partitions == null)
                {
                    _partitions = new List<TimeSlot>();
                }

                return _partitions;
            }
        }

        private static List<TimeSlot> _partitions;



        public void AddTimeSlot(FrameLogic timeSlotLogic, int frameTarget)
        {
            partitions.Add(new TimeSlot(timeSlotLogic, frameTarget));
        }


        public virtual void Update()
        {
            for (int i = 0; i < partitions.Count; i++)
            {
                partitions[i].Update();
            }
        }
    }





}
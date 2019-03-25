using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TaskSpace
{
    public class task
    {
        public enum TaskStatus
        {
            executing,
            waiting,
            aborted
        }
        private TaskStatus currentStatus = TaskStatus.executing;

        public TaskStatus GetTaskStatus()
        {
            return currentStatus;
        }

        public void SetTaskStatus(TaskStatus a)
        {
            if (currentStatus == a) return;
            else currentStatus = a;
        }

        internal virtual void Update() { }
    }

    public class taskProcessor:task
    {
        public task shoottask1;
        public task shoottask2;
        public task movetask;
        public ExplodeTask explosiontask;
      //  public bool HasTasks { get { return tasks.Count > 0; } }

        public TankHealth t;
        public float FlagForStage2 = 350;
        public float FlagForStage3 = 0;

        internal override void Update()
        {
            if(t.TankCurentHealth>FlagForStage2)
            {
                shoottask1.Update();
                shoottask2.Update();
            }
            else if(t.TankCurentHealth<=FlagForStage2&&t.TankCurentHealth>FlagForStage3)
            {
                shoottask1.Update();
                shoottask2.Update();
                movetask.Update();
            }else if(t.TankCurentHealth<=FlagForStage3)
            {
                explosiontask.Explode();
            }
        }
    }
}
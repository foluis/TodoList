﻿using System;

namespace Na.TodoList.Domain.ApiModels
{
    public class SimpleObject
    {
        public int Id { get; set; }
        public string URL { get; set; }
        public string FieldId { get; set; }
        public string ValueToInject { get; set; }
        public DateTime RequestTime { get; set; }

    }
}

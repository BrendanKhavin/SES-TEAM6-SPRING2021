using System;
using System.Collections.Generic;


public class SubjectModel
{

    //Use later

	public Guid ID { get; set; }

    public string SubjectName { get; set; }

    public string SubjectCode { get; set; }

    public string Description { get; set; }

    public int CreditPoints { get; set; }

    public List<SubjectModel> PreRequists { get; set; }

    public List<SubjectModel> AntiRequists { get; set; }

    

}


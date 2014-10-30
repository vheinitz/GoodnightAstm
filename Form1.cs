/*
 * Valentin Heinitz, 2014-10-30 01:54
 * http://heinitz-it.de
 * ASTM-1394 parser. Parses contents of text in the text-area into object. That's all for now.
 * Don't expect proper functioning or completeness. These are my first steps in C#.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

//:1,$s/.*(\([^,]*\),.,\("[^"]*"\),"\([^"]*\)",\("[^"]*"\)).*/String f_\3;\/\/ \4/
//:1,$s/.*(\([^,]*\),.,\("[^"]*"\),"\([^"]*\)",\("[^"]*"\)).*/\tcase (\1):f_\3=v; break;/
namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        abstract class  ASTM_Record 
        {

            public abstract  bool parseData(String recordData);
        }

        class ASTM_Comment : ASTM_Record
        {
            String f_type;// "Record Type ID"
            String f_seq;// "Sequence Number"
            public String f_source;// "Comment Source"
            public String f_data;// "Comment Text"
            public String f_ctype;// "Comment Type"

            public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();


            public override bool parseData(String recordData)
            {
                var recordValues = Regex.Split(recordData, "[|]");
                int idx = 1;
                foreach (var v in recordValues)
                {
                    switch (idx)
                    {
                        case (1): f_type = v; break;
                        case (2): f_seq = v; break;
                        case (3): f_source = v; break;
                        case (4): f_data = v; break;
                        case (5): f_ctype = v; break;
                        default: return false;
                    }
                    idx++;
                }
                return true;
            }
        }

        class ASTM_Manufacturer : ASTM_Record
        {
            String f_type;// "Record Type ID"
            String f_seq;// "Sequence Number"
            public String f_mf1;// "Manufacturer Field 1"
            public String f_mf2;// "Manufacturer Field 2"
            public String f_mf3;// "Manufacturer Field 3"
            public String f_mf4;// "Manufacturer Field 4"
            public String f_mf5;// "Manufacturer Field 5"

            public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();

            public override bool parseData(String recordData)
            {
                var recordValues = Regex.Split(recordData, "[|]");
                int idx = 1;
                foreach (var v in recordValues)
                {
                    switch (idx)
                    {
                        case (1): f_type = v; break;
                        case (2): f_seq = v; break;
                        case (3): f_mf1 = v; break;
                        case (4): f_mf2 = v; break;
                        case (5): f_mf3 = v; break;
                        case (6): f_mf4 = v; break;
                        case (7): f_mf5 = v; break;
                        default: return false;
                    }
                    idx++;
                }
                return true;
            }
        }

        class ASTM_Scientific : ASTM_Record
        {
            String f_type;// "Record Type ID"
            String f_seq;// "Sequence Number"
            public String f_anmeth;// "Analytical Method"
            public String f_instr;// "Instrumentation"
            public String f_reagents;// "Reagents"
            public String f_unitofmeas;// "Units of Measure"
            public String f_qc;// "Quality Control"
            public String f_spcmdescr;// "Specimen Descriptor"
            public String f_resrvd;// "Reserved Field"
            public String f_container;// "Container"
            public String f_spcmid;// "Specimen ID"
            public String f_analyte;// "Analyte"
            public String f_result;// "Result"
            public String f_resunts;// "Result Units"
            public String f_collctdt;// "Collection Date and Time"
            public String f_resdt;// "Result Date and Time"
            public String f_anlprocstp;// "Analytical Preprocessing Steps"
            public String f_patdiagn;// "Patient Diagnosis"
            public String f_patbd;// "Patient Birthdate"
            public String f_patsex;// "Patient Sex"
            public String f_patrace;// "Patient Race"

            public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();
            public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();

            public override bool parseData(String recordData)
            {
                var recordValues = Regex.Split(recordData, "[|]");
                int idx = 1;
                foreach (var v in recordValues)
                {
                    switch (idx)
                    {
                        case (1): f_type = v; break;
                        case (2): f_seq = v; break;
                        case (3): f_anmeth = v; break;
                        case (4): f_instr = v; break;
                        case (5): f_reagents = v; break;
                        case (6): f_unitofmeas = v; break;
                        case (7): f_qc = v; break;
                        case (8): f_spcmdescr = v; break;
                        case (9): f_resrvd = v; break;
                        case (10): f_container = v; break;
                        case (11): f_spcmid = v; break;
                        case (12): f_analyte = v; break;
                        case (13): f_result = v; break;
                        case (14): f_resunts = v; break;
                        case (15): f_collctdt = v; break;
                        case (16): f_resdt = v; break;
                        case (17): f_anlprocstp = v; break;
                        case (18): f_patdiagn = v; break;
                        case (19): f_patbd = v; break;
                        case (20): f_patsex = v; break;
                        case (21): f_patrace = v; break;
                        default: return false;
                    }
                    idx++;
                }
                return true;
            }
        }

        class ASTM_Order : ASTM_Record
        {
            String f_type;// "Record Type ID"
            String f_seq;// "Sequence Number"
            public String f_sample_id;// "Specimen ID"
            public String f_instrument;// "Instrument Specimen ID"
            public String f_test;// "Universal Test ID"
            public String f_priority;// "Priority"
            public String f_created_at;// "Requested/Ordered Date/Time"
            public String f_sampled_at;// "Specimen Collection Date/Time"
            public String f_collected_at;// "Collection End Time"
            public String f_volume;// "Collection Volume"
            public String f_collector;// "Collector ID"
            public String f_action_code;// "Action Code"
            public String f_danger_code;// "Danger Code"
            public String f_clinical_info;// "Relevant Information"
            public String f_delivered_at;// "Date/Time Specimen Received"
            public String f_biomaterial;// "Specimen Descriptor"
            public String f_physician;// "Ordering Physician"
            public String f_physician_phone;// "Physician?s Telephone Number"
            public String f_user_field_1;// "User Field No. 1"
            public String f_user_field_2;// "User Field No. 2"
            public String f_laboratory_field_1;// "Laboratory Field No. 1"
            public String f_laboratory_field_2;// "Laboratory Field No. 2"
            public String f_modified_at;// "Date/Time Reported"
            public String f_instrument_charge;// "Instrument Charge"
            public String f_instrument_section;// "Instrument Section ID"
            public String f_report_type;// "Report Type"

            public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();
            public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();


            public override bool parseData(String recordData)
            {
                var recordValues = Regex.Split(recordData, "[|]");
                int idx = 1;
                foreach (var v in recordValues)
                {
                    switch (idx)
                    {
                        case (1): f_type = v; break;
                        case (2): f_seq = v; break;
                        case (3): f_sample_id = v; break;
                        case (4): f_instrument = v; break;
                        case (5): f_test = v; break;
                        case (6): f_priority = v; break;
                        case (7): f_created_at = v; break;
                        case (8): f_sampled_at = v; break;
                        case (9): f_collected_at = v; break;
                        case (10): f_volume = v; break;
                        case (11): f_collector = v; break;
                        case (12): f_action_code = v; break;
                        case (13): f_danger_code = v; break;
                        case (14): f_clinical_info = v; break;
                        case (15): f_delivered_at = v; break;
                        case (16): f_biomaterial = v; break;
                        case (17): f_physician = v; break;
                        case (18): f_physician_phone = v; break;
                        case (19): f_user_field_1 = v; break;
                        case (20): f_user_field_2 = v; break;
                        case (21): f_laboratory_field_1 = v; break;
                        case (22): f_laboratory_field_2 = v; break;
                        case (23): f_modified_at = v; break;
                        case (24): f_instrument_charge = v; break;
                        case (25): f_instrument_section = v; break;
                        case (26): f_report_type = v; break;
                        default: return false;
                    }
                    idx++;
                }
                return true;
            }
        }

        class ASTM_Result : ASTM_Record
        {
            String f_type;// "Record Type ID"
            String f_seq;// "Sequence Number"
            public String f_test;// "Universal Test ID"
            public String f_value;// "Data or Measurement Value"
            public String f_units;// "Units"
            public String f_references;// "Reference Ranges"
            public String f_abnormal_flag;// "Result Abnormal Flags"
            public String f_abnormality_nature;// "Nature of Abnormal Testing"
            public String f_status;// "Results Status"
            public String f_norms_changed_at;// "Date of Changein Instrument"
            public String f_operator;// "Operator Identification"
            public String f_started_at;// "Date/Time Test Started"
            public String f_completed_at;// "Date/Time Test Complete"
            public String f_instrument;// "Instrument Identification"

            public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();            
            public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();


            public override bool parseData(String recordData)
            {
                var recordValues = Regex.Split(recordData, "[|]");
                int idx = 1;
                foreach (var v in recordValues)
                {
                    switch (idx)
                    {
                        case (1): f_type = v; break;
                        case (2): f_seq = v; break;
                        case (3): f_test = v; break;
                        case (4): f_value = v; break;
                        case (5): f_units = v; break;
                        case (6): f_references = v; break;
                        case (7): f_abnormal_flag = v; break;
                        case (8): f_abnormality_nature = v; break;
                        case (9): f_status = v; break;
                        case (10): f_norms_changed_at = v; break;
                        case (11): f_operator = v; break;
                        case (12): f_started_at = v; break;
                        case (13): f_completed_at = v; break;
                        case (14): f_instrument = v; break;
                        default: return false;
                    }
                    idx++;
                }
                return true;
            }
        }


        class ASTM_Patient : ASTM_Record
        {
            String f_type;// "Record Type ID"
            String f_seq;// "Sequence Number"
            public String f_practice_id;// "Practice Assigned Patient ID"
            public String f_laboratory_id;// "Laboratory Assigned Patient ID"
            public String f_id;// "Patient ID"
            public String f_name;// "Patient Name"
            public String f_maiden_name;// "Mother?s Maiden Name"
            public String f_birthdate;// "Birthdate"
            public String f_sex;// "Patient Sex"
            public String f_race;// "Patient Race-, Ethnic Origin"
            public String f_address;// "Patient Address"
            public String f_reserved;// "Reserved Field"
            public String f_phone;// "Patient Telephone Number"
            public String f_physician_id;// "Attending Physician ID"
            public String f_special_1;// "Special Field No. 1"
            public String f_special_2;// "Special Field No. 2"
            public String f_height;// "Patient Height"
            public String f_weight;// "Patient Weight"
            public String f_diagnosis;// "Patient?s Known Diagnosis"
            public String f_medication;// "Patient?s Active Medication"
            public String f_diet;// "Patient?s Diet"
            public String f_practice_field_1;// "Practice Field No. 1"
            public String f_practice_field_2;// "Practice Field No. 2"
            public String f_admission_date;// "Admission/Discharge Dates"
            public String f_admission_status;// "Admission Status"
            public String f_location;// "Location"

            public List<ASTM_Manufacturer> manufacturerRecords = new  List<ASTM_Manufacturer>();
            public List<ASTM_Order> orderRecords = new List<ASTM_Order>();
            public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();


            public override bool parseData(String recordData)
            {
                var recordValues = Regex.Split(recordData, "[|]");
                int idx = 1;
                foreach (var v in recordValues)
                {
                    switch (idx)
                    {
                        case (1): f_type = v; break;
                        case (2): f_seq = v; break;
                        case (3): f_practice_id = v; break;
                        case (4): f_laboratory_id = v; break;
                        case (5): f_id = v; break;
                        case (6): f_name = v; break;
                        case (7): f_maiden_name = v; break;
                        case (8): f_birthdate = v; break;
                        case (9): f_sex = v; break;
                        case (10): f_race = v; break;
                        case (11): f_address = v; break;
                        case (12): f_reserved = v; break;
                        case (13): f_phone = v; break;
                        case (14): f_physician_id = v; break;
                        case (15): f_special_1 = v; break;
                        case (16): f_special_2 = v; break;
                        case (17): f_height = v; break;
                        case (18): f_weight = v; break;
                        case (19): f_diagnosis = v; break;
                        case (20): f_medication = v; break;
                        case (21): f_diet = v; break;
                        case (22): f_practice_field_1 = v; break;
                        case (23): f_practice_field_2 = v; break;
                        case (24): f_admission_date = v; break;
                        case (25): f_admission_status = v; break;
                        case (26): f_location = v; break;
                        default: return false;
                    }
                    idx++;
                }
                return true;
            }
        }

        class ASTM_Request : ASTM_Record
        {
            String f_type;// "Record Type ID"
            String f_seq;// "Sequence Number"
            public String f_srangeid;// "Starting Range ID Number"
            public String f_erangeid;// "Ending Range ID Number"
            public String f_utestid;// "Universal Test ID"
            public String f_noreqtmlim;// "Nature of Request Time Limits"
            public String f_begreqresdt;// "Beginning Request Results Date and Time"
            public String f_endreqresdt;// "Ending Request Results Date and Time"
            public String f_reqphysname;// "Requesting Physician Name"
            public String f_reqphystel;// "Requesting Physician Telephone Number"
            public String f_userfld1;// "User Field No. 1"
            public String f_userfld2;// "User Field No. 2"
            public String f_statcodes;// "Request Information Status Codes"

            public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();
            public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();

            public override bool parseData(String recordData)
            {
                var recordValues = Regex.Split(recordData, "[|]");
                int idx = 1;
                foreach (var v in recordValues)
                {
                    switch (idx)
                    {
                        case (1): f_type = v; break;
                        case (2): f_seq = v; break;
                        case (3): f_srangeid = v; break;
                        case (4): f_erangeid = v; break;
                        case (5): f_utestid = v; break;
                        case (6): f_noreqtmlim = v; break;
                        case (7): f_begreqresdt = v; break;
                        case (8): f_endreqresdt = v; break;
                        case (9): f_reqphysname = v; break;
                        case (10): f_reqphystel = v; break;
                        case (11): f_userfld1 = v; break;
                        case (12): f_userfld2 = v; break;
                        case (13): f_statcodes = v; break;
                        default: return false;
                    }
                    idx++;
                }
                return true;
            }

        }


        class ASTM_Message : ASTM_Record
        {
            String f_type;// "Record Type ID"
            String f_delimeter;// "Delimiter Definition"
            public String f_message_id;// "Message Control ID"
            public String f_password;// "Access Password"
            public String f_sender;// "Sender Nameor ID"
            public String f_address;// "Sender Street Address"
            public String f_reserved;// "Reserved Field"
            public String f_phone;// "Sender Telephone Number"
            public String f_caps;// "Characteristics of Sender"
            public String f_receiver;// "Receiver ID"
            public String f_comments;// "Comments"
            public String f_processing_id;// "Processing ID"
            public String f_version;// "Version Number"
            public String f_timestamp;// "Date/Timeof Message"

            public List<ASTM_Manufacturer> manufacturerRecords = new List<ASTM_Manufacturer>();
            public List<ASTM_Scientific> scientificRecords = new List<ASTM_Scientific>();
            public List<ASTM_Patient> patientRecords = new List<ASTM_Patient>();
            public List<ASTM_Comment> commentRecords = new List<ASTM_Comment>();
            public List<ASTM_Request> requestRecords = new List<ASTM_Request>();

            public override bool parseData(String recordData)
            {
                var recordValues = Regex.Split(recordData, "[|]");
                int idx=1;
                foreach (var v in recordValues)
                {
                    switch(idx)
                    {
    	                case (1):f_type=v; break;
	                    case (2):f_delimeter=v; break;
	                    case (3):f_message_id=v; break;
	                    case (4):f_password=v; break;
	                    case (5):f_sender=v; break;
	                    case (6):f_address=v; break;
	                    case (7):f_reserved=v; break;
	                    case (8):f_phone=v; break;
	                    case (9):f_caps=v; break;
	                    case (10):f_receiver=v; break;
	                    case (11):f_comments=v; break;
	                    case (12):f_processing_id=v; break;
	                    case (13):f_version=v; break;
	                    case (14):f_timestamp=v; break;
                        default: return false;
                    }
                    idx++;
                }
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String text = this.astmData.Text;
            var lines = Regex.Split(text, "\r\n|\r|\n");
            ASTM_Message m = null;
            ASTM_Record curRec = null;
            foreach (var l in lines)
            { 
                var entries = Regex.Split(l, "[|]");
                switch (entries.ElementAt(0))
                { 
                    case "H":
                        m = new ASTM_Message();
                        curRec = m;
                        curRec.parseData(l);
                        break;
                    case "P":
                        if (m != null)
                        {
                            m.patientRecords.Add(new ASTM_Patient());
                            curRec = m.patientRecords.Last();
                            curRec.parseData(l);
                        }
                        else
                        { 
                            //TODO Error
                        }
                        break;
                    case "O":
                        if (m != null)
                        {
                            if (m.patientRecords.Count > 0 && m.patientRecords.Last() != null)
                            {
                                m.patientRecords.Last().orderRecords.Add(new ASTM_Order());
                                curRec = m.patientRecords.Last().orderRecords.Last();
                                curRec.parseData(l);
                            }
                            else
                            {
                                //TODO Error: no patient
                            }
                        }
                        else
                        {
                            //TODO Error
                        }
                        break;
                    case "Q":
                        if (m != null)
                        {
                            m.requestRecords.Add(new ASTM_Request());
                            curRec = m.requestRecords.Last();
                            curRec.parseData(l);
                        }
                        else
                        {
                            //TODO Error
                        }
                        break;
                    case "L":
                    default:

                        break;
                }

            }  
        }
    }
}

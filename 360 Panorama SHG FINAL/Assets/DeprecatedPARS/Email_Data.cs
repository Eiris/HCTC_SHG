using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.IO;
using System;

public class Email_Data : MonoBehaviour {


	public void sendAutoMail ()
	{
		MailMessage mail = new MailMessage();

		mail.From = new MailAddress("News" );
//		mail.To.Add("rikardoeiris@gmail.com");
		mail.To.Add("hfmoore@ufl.edu");
		mail.Subject = "Results from PARS Experiment";
		mail.Body = "These are some results from running the experiment";
		string ss = SystemInfo.deviceUniqueIdentifier;
		mail.Attachments.Add (new Attachment(Path.GetTempPath() + "\\PanoExperiment_" + ss + ".zip"));
		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
		smtpServer.Port = 587;
		smtpServer.Credentials = new System.Net.NetworkCredential("unitygametestemail@gmail.com", "ricardoeiris") as ICredentialsByHost;
		smtpServer.EnableSsl = true;
		ServicePointManager.ServerCertificateValidationCallback =
			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{ return true; };
		smtpServer.Send(mail);

//
//		System.IO.Directory.Delete ((Path.GetTempPath () + "\\PanoExperiment_" + ss), true);
//		System.IO.Directory.Delete ((Path.GetTempPath () + "\\PanoExperiment_" + ss + ".zip"), true);
//		yield return null;
		//		Debug.Log ("IT WORKS!");
	}

//	void Start(){
//		//TODO: I have to figure a way to zip folders here
//		StartCoroutine(sendAutoMail ());
//	}
//
//	private IEnumerator sendAutoMail ()
//	{
//		MailMessage mail = new MailMessage();
//
//		mail.From = new MailAddress("News");
//		mail.To.Add("rikardoeiris@gmail.com");
//		mail.Subject = "Test";
//		mail.Body = "Hello World";
//		string ss = SystemInfo.deviceUniqueIdentifier;
//		mail.Attachments.Add (new Attachment(Path.GetTempPath() + "\\PanoExperiment_" + ss + ".zip"));
//		SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
//		smtpServer.Port = 587;
//		smtpServer.Credentials = new System.Net.NetworkCredential("unitygametestemail@gmail.com", "ricardoeiris") as ICredentialsByHost;
//		smtpServer.EnableSsl = true;
//		ServicePointManager.ServerCertificateValidationCallback =
//			delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
//		{ return true; };
//		smtpServer.Send(mail);
//		yield return null;
////		Debug.Log ("IT WORKS!");
//	}

}

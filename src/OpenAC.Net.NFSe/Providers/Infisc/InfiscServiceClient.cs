// ***********************************************************************
// Assembly         : OpenAC.Net.NFSe
// Author           : Diego Martins
// Created          : 08-29-2021
//
// Last Modified By : Dheizon Gonçalves
// Last Modified On : 29-05-2023
// ***********************************************************************
// <copyright file="InfiscServiceClient.cs" company="OpenAC .Net">
//		        		   The MIT License (MIT)
//	     		    Copyright (c) 2014 - 2023 Projeto OpenAC .Net
//
//	 Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the "Software"),
// to deal in the Software without restriction, including without limitation
// the rights to use, copy, modify, merge, publish, distribute, sublicense,
// and/or sell copies of the Software, and to permit persons to whom the
// Software is furnished to do so, subject to the following conditions:
//	 The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
//	 THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
// ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
// DEALINGS IN THE SOFTWARE.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Xml.Linq;
using OpenAC.Net.Core.Extensions;
using OpenAC.Net.DFe.Core;

namespace OpenAC.Net.NFSe.Providers;

internal sealed class InfiscServiceClient : NFSeSoapServiceClient, IServiceClient
{
    #region Constructors

    public InfiscServiceClient(ProviderInfisc provider, TipoUrl tipoUrl) : base(provider, tipoUrl, SoapVersion.Soap11)
    {
    }

    public InfiscServiceClient(ProviderInfisc provider, TipoUrl tipoUrl, X509Certificate2 certificado) : base(provider, tipoUrl, certificado, SoapVersion.Soap11)
    {
    }

    #endregion Constructors

    #region Methods

    public string CancelarNFSe(string cabec, string msg)
    {
        return Execute("https://www.e-governeapps2.com.br/CancelarNfse", msg.ToString(), "CancelarNfseResponse");
    }

    public string CancelarNFSeLote(string cabec, string msg)
    {
        throw new NotImplementedException();
    }

    public string ConsultarLoteRps(string cabec, string msg)
    {
        return Execute("https://www.e-governeapps2.com.br/ConsultarLoteRps", msg.ToString(), "ConsultarLoteRpsResponse");
    }

    public string ConsultarNFSe(string cabec, string msg)
    {
        return Execute("https://www.e-governeapps2.com.br/ConsultarNfse", msg.ToString(), "ConsultarNfseResponse");
    }

    public string ConsultarNFSeRps(string cabec, string msg)
    {
        return Execute("https://www.e-governeapps2.com.br/ConsultarNfsePorRps", msg.ToString(), "ConsultarNfsePorRpsResponse");
    }

    public string ConsultarSequencialRps(string cabec, string msg)
    {
        throw new NotImplementedException();
    }

    public string ConsultarSituacao(string cabec, string msg)
    {
        return Execute("https://www.e-governeapps2.com.br/ConsultarSituacaoLoteRps", msg.ToString(), "ConsultarSituacaoLoteRpsResult");
    }

    public string Enviar(string cabec, string msg)
    {
        return Execute("https://campobom-gif4homol.infisc.com.br/services/nfse/ws/Servicos.wsdl", msg.ToString(), "enviarLoteNotas");
    }

    public string EnviarSincrono(string cabec, string msg)
    {
        throw new NotImplementedException();
    }

    public string SubstituirNFSe(string cabec, string msg)
    {
        throw new NotImplementedException();
    }

    //protected override string Execute(string soapAction, string message, string soapHeader, string[] responseTag, params string[] soapNamespaces)
    //{
    //    var envelope = new StringBuilder();
    //    switch (MessageVersion)
    //    {
    //        case SoapVersion.Soap11:
    //            envelope.Append("<soapenv:Envelope xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" ");
    //            break;

    //        case SoapVersion.Soap12:
    //            envelope.Append("<soapenv:Envelope xmlns:soapenv=\"http://www.w3.org/2003/05/soap-envelope\" ");
    //            break;

    //        default:
    //            throw new ArgumentOutOfRangeException();
    //    }

    //    envelope.Append("xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" ");
    //    envelope.Append("xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">");
    //    envelope.Append("<soapenv:Body>");
    //    envelope.Append($"<ns1:{responseTag[0]} xmlns:ns1=\"http://ws.pc.gif.com.br/\">");
    //    envelope.Append("<xml xsi:type=\"xsd:string\">");
    //    envelope.Append(message);
    //    envelope.Append("</xml>");
    //    envelope.Append("</ns1:");
    //    envelope.Append(responseTag[0]);
    //    envelope.Append(">");
    //    envelope.Append("</soapenv:Body>");
    //    envelope.Append("</soapenv:Envelope>");
    //    EnvelopeEnvio = envelope.ToString();

    //StringContent content;
    //    switch (MessageVersion)
    //    {
    //        case SoapVersion.Soap11:
    //            content = new StringContent(EnvelopeEnvio, CharSet, "text/xml");
    //            if (Provider.Name != NFSeProvider.Infisc.ToString())
    //                content.Headers.Add("SOAPAction", $"\"{soapAction}\"");
    //            break;

    //        case SoapVersion.Soap12:
    //            content = new StringContent(EnvelopeEnvio, CharSet, "application/soap+xml");
    //            content.Headers.ContentType?.Parameters.Add(new NameValueHeaderValue("action", $"\"{soapAction}\""));
    //            break;

    //        default:
    //            throw new ArgumentOutOfRangeException();
    //    }

    //    Execute(content, HttpMethod.Post);

    //   if (!EnvelopeRetorno.IsValidXml())
    //        throw new OpenDFeCommunicationException("Erro ao processar o xml do envelope SOAP => " + EnvelopeRetorno);

    //    var xmlDocument = XDocument.Parse(EnvelopeRetorno);
    //    var body = xmlDocument.ElementAnyNs("Envelope").ElementAnyNs("Body");
    //    var retorno = TratarRetorno(body, responseTag);
    //    if (retorno.IsValidXml()) return retorno;

    //    if (retorno != null)
    //        throw new OpenDFeCommunicationException("Erro ao processar o retorno(1) => " + retorno);

    //    throw new OpenDFeCommunicationException("Erro ao processar o retorno(2) => " + EnvelopeRetorno);
    //}


    private string Execute(string action, string message, string responseTag)
    {
        return Execute(action, message, responseTag, new string[0]);
    }

    protected override string TratarRetorno(XElement xmlDocument, string[] responseTag)
    {
        var element = xmlDocument.ElementAnyNs("Fault");
        if (element == null) return xmlDocument.ToString();

        var exMessage = $"{element.ElementAnyNs("faultcode").GetValue<string>()} - {element.ElementAnyNs("faultstring").GetValue<string>()}";
        throw new OpenDFeCommunicationException(exMessage);
    }

    #endregion Methods
}
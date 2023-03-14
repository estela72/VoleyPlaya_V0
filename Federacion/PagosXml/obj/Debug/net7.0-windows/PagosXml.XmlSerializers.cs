[assembly:System.Security.AllowPartiallyTrustedCallers()]
[assembly:System.Security.SecurityTransparent()]
[assembly:System.Security.SecurityRules(System.Security.SecurityRuleSet.Level1)]
[assembly:System.Xml.Serialization.XmlSerializerVersionAttribute(ParentAssemblyId=@"dc24fd89-2db1-4492-9661-78fd64bd6b74,", Version=@"1.0.0.0")]
namespace Microsoft.Xml.Serialization.GeneratedAssembly {

    public class XmlSerializationWriter1 : System.Xml.Serialization.XmlSerializationWriter {

        public void Write59_Document(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteEmptyTag(@"Document", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
                return;
            }
            TopLevelElement();
            Write30_Document(@"Document", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::Document)o), false, false);
        }

        public void Write60_DocumentCstmrCdtTrfInitn(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitn", @"");
                return;
            }
            TopLevelElement();
            Write31_DocumentCstmrCdtTrfInitn(@"DocumentCstmrCdtTrfInitn", @"", ((global::DocumentCstmrCdtTrfInitn)o), true, false);
        }

        public void Write61_DocumentCstmrCdtTrfInitnGrpHdr(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnGrpHdr", @"");
                return;
            }
            TopLevelElement();
            Write32_DocumentCstmrCdtTrfInitnGrpHdr(@"DocumentCstmrCdtTrfInitnGrpHdr", @"", ((global::DocumentCstmrCdtTrfInitnGrpHdr)o), true, false);
        }

        public void Write62_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPty", @"");
                return;
            }
            TopLevelElement();
            Write33_Item(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPty", @"", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty)o), true, false);
        }

        public void Write63_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID", @"");
                return;
            }
            TopLevelElement();
            Write34_Item(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID", @"", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID)o), true, false);
        }

        public void Write64_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId", @"");
                return;
            }
            TopLevelElement();
            Write35_Item(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId", @"", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId)o), true, false);
        }

        public void Write65_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr", @"");
                return;
            }
            TopLevelElement();
            Write36_Item(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr", @"", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr)o), true, false);
        }

        public void Write66_DocumentCstmrCdtTrfInitnPmtInf(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInf", @"");
                return;
            }
            TopLevelElement();
            Write37_DocumentCstmrCdtTrfInitnPmtInf(@"DocumentCstmrCdtTrfInitnPmtInf", @"", ((global::DocumentCstmrCdtTrfInitnPmtInf)o), true, false);
        }

        public void Write67_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfDbtr", @"");
                return;
            }
            TopLevelElement();
            Write38_Item(@"DocumentCstmrCdtTrfInitnPmtInfDbtr", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtr)o), true, false);
        }

        public void Write68_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfDbtrID", @"");
                return;
            }
            TopLevelElement();
            Write39_Item(@"DocumentCstmrCdtTrfInitnPmtInfDbtrID", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrID)o), true, false);
        }

        public void Write69_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId", @"");
                return;
            }
            TopLevelElement();
            Write40_Item(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId)o), true, false);
        }

        public void Write70_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr", @"");
                return;
            }
            TopLevelElement();
            Write41_Item(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr)o), true, false);
        }

        public void Write71_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcct", @"");
                return;
            }
            TopLevelElement();
            Write42_Item(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcct", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct)o), true, false);
        }

        public void Write72_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID", @"");
                return;
            }
            TopLevelElement();
            Write43_Item(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID)o), true, false);
        }

        public void Write73_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgt", @"");
                return;
            }
            TopLevelElement();
            Write44_Item(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgt", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt)o), true, false);
        }

        public void Write74_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId", @"");
                return;
            }
            TopLevelElement();
            Write45_Item(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId)o), true, false);
        }

        public void Write75_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf", @"");
                return;
            }
            TopLevelElement();
            Write46_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf)o), true, false);
        }

        public void Write76_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId", @"");
                return;
            }
            TopLevelElement();
            Write47_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId)o), true, false);
        }

        public void Write77_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf", @"");
                return;
            }
            TopLevelElement();
            Write48_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf)o), true, false);
        }

        public void Write78_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl", @"");
                return;
            }
            TopLevelElement();
            Write49_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl)o), true, false);
        }

        public void Write79_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt", @"");
                return;
            }
            TopLevelElement();
            Write50_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt)o), true, false);
        }

        public void Write80_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt", @"");
                return;
            }
            TopLevelElement();
            Write51_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt)o), true, false);
        }

        public void Write81_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr", @"");
                return;
            }
            TopLevelElement();
            Write52_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr)o), true, false);
        }

        public void Write82_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID", @"");
                return;
            }
            TopLevelElement();
            Write53_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID)o), true, false);
        }

        public void Write83_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId", @"");
                return;
            }
            TopLevelElement();
            Write54_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId)o), true, false);
        }

        public void Write84_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr", @"");
                return;
            }
            TopLevelElement();
            Write55_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr)o), true, false);
        }

        public void Write85_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct", @"");
                return;
            }
            TopLevelElement();
            Write56_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct)o), true, false);
        }

        public void Write86_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID", @"");
                return;
            }
            TopLevelElement();
            Write57_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID)o), true, false);
        }

        public void Write87_Item(object o) {
            WriteStartDocument();
            if (o == null) {
                WriteNullTagLiteral(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf", @"");
                return;
            }
            TopLevelElement();
            Write58_Item(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf", @"", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf)o), true, false);
        }

        void Write58_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Ustrd", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Ustrd));
            WriteEndElement(o);
        }

        void Write57_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"IBAN", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@IBAN));
            WriteEndElement(o);
        }

        void Write56_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write24_Item(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID)o.@Id), false, false);
            WriteEndElement(o);
        }

        void Write24_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"IBAN", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@IBAN));
            WriteEndElement(o);
        }

        void Write55_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Id));
            WriteEndElement(o);
        }

        void Write54_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write20_Item(@"Othr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr)o.@Othr), false, false);
            WriteEndElement(o);
        }

        void Write20_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Id));
            WriteEndElement(o);
        }

        void Write53_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write21_Item(@"PrvtId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId)o.@PrvtId), false, false);
            WriteEndElement(o);
        }

        void Write21_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write20_Item(@"Othr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr)o.@Othr), false, false);
            WriteEndElement(o);
        }

        void Write52_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Nm", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Nm));
            Write22_Item(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID)o.@Id), false, false);
            WriteEndElement(o);
        }

        void Write22_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write21_Item(@"PrvtId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId)o.@PrvtId), false, false);
            WriteEndElement(o);
        }

        void Write51_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteAttribute(@"Ccy", @"", ((global::System.String)o.@Ccy));
            {
                WriteValue(System.Xml.XmlConvert.ToString((global::System.Single)((global::System.Single)o.@Value)));
            }
            WriteEndElement(o);
        }

        void Write50_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write18_Item(@"InstdAmt", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt)o.@InstdAmt), false, false);
            WriteEndElement(o);
        }

        void Write18_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteAttribute(@"Ccy", @"", ((global::System.String)o.@Ccy));
            {
                WriteValue(System.Xml.XmlConvert.ToString((global::System.Single)((global::System.Single)o.@Value)));
            }
            WriteEndElement(o);
        }

        void Write49_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Cd", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Cd));
            WriteEndElement(o);
        }

        void Write48_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write16_Item(@"SvcLvl", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl)o.@SvcLvl), false, false);
            WriteEndElement(o);
        }

        void Write16_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Cd", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Cd));
            WriteEndElement(o);
        }

        void Write47_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementStringRaw(@"EndToEndId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", System.Xml.XmlConvert.ToString((global::System.Int16)((global::System.Int16)o.@EndToEndId)));
            WriteEndElement(o);
        }

        void Write46_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write15_Item(@"PmtId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId)o.@PmtId), false, false);
            Write17_Item(@"PmtTpInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf)o.@PmtTpInf), false, false);
            Write19_Item(@"Amt", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt)o.@Amt), false, false);
            Write23_Item(@"Cdtr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr)o.@Cdtr), false, false);
            Write25_Item(@"CdtrAcct", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct)o.@CdtrAcct), false, false);
            Write26_Item(@"RmtInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf)o.@RmtInf), false, false);
            WriteEndElement(o);
        }

        void Write26_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Ustrd", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Ustrd));
            WriteEndElement(o);
        }

        void Write25_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write24_Item(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID)o.@Id), false, false);
            WriteEndElement(o);
        }

        void Write23_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Nm", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Nm));
            Write22_Item(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID)o.@Id), false, false);
            WriteEndElement(o);
        }

        void Write19_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write18_Item(@"InstdAmt", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt)o.@InstdAmt), false, false);
            WriteEndElement(o);
        }

        void Write17_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write16_Item(@"SvcLvl", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl)o.@SvcLvl), false, false);
            WriteEndElement(o);
        }

        void Write15_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementStringRaw(@"EndToEndId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", System.Xml.XmlConvert.ToString((global::System.Int16)((global::System.Int16)o.@EndToEndId)));
            WriteEndElement(o);
        }

        void Write45_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"BIC", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@BIC));
            WriteEndElement(o);
        }

        void Write44_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgt", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write13_Item(@"FinInstnId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId)o.@FinInstnId), false, false);
            WriteEndElement(o);
        }

        void Write13_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"BIC", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@BIC));
            WriteEndElement(o);
        }

        void Write43_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"IBAN", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@IBAN));
            WriteEndElement(o);
        }

        void Write42_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcct", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write11_Item(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID)o.@Id), false, false);
            WriteElementString(@"Ccy", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Ccy));
            WriteEndElement(o);
        }

        void Write11_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"IBAN", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@IBAN));
            WriteEndElement(o);
        }

        void Write41_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Id));
            WriteEndElement(o);
        }

        void Write40_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write7_Item(@"Othr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr)o.@Othr), false, false);
            WriteEndElement(o);
        }

        void Write7_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Id));
            WriteEndElement(o);
        }

        void Write39_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrID o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrID)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfDbtrID", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write8_Item(@"OrgId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId)o.@OrgId), false, false);
            WriteEndElement(o);
        }

        void Write8_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write7_Item(@"Othr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr)o.@Othr), false, false);
            WriteEndElement(o);
        }

        void Write38_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInfDbtr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Nm", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Nm));
            Write9_Item(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrID)o.@Id), false, false);
            WriteEndElement(o);
        }

        void Write9_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrID o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrID)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write8_Item(@"OrgId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId)o.@OrgId), false, false);
            WriteEndElement(o);
        }

        void Write37_DocumentCstmrCdtTrfInitnPmtInf(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInf o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInf)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnPmtInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"PmtInfId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@PmtInfId));
            WriteElementString(@"PmtMtd", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@PmtMtd));
            WriteElementStringRaw(@"ReqdExctnDt", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", FromDate(((global::System.DateTime)o.@ReqdExctnDt)));
            Write10_Item(@"Dbtr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtr)o.@Dbtr), false, false);
            Write12_Item(@"DbtrAcct", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct)o.@DbtrAcct), false, false);
            Write14_Item(@"DbtrAgt", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt)o.@DbtrAgt), false, false);
            {
                global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[] a = (global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[])o.@CdtTrfTxInf;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write27_Item(@"CdtTrfTxInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf)a[ia]), false, false);
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write27_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write15_Item(@"PmtId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId)o.@PmtId), false, false);
            Write17_Item(@"PmtTpInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf)o.@PmtTpInf), false, false);
            Write19_Item(@"Amt", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt)o.@Amt), false, false);
            Write23_Item(@"Cdtr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr)o.@Cdtr), false, false);
            Write25_Item(@"CdtrAcct", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct)o.@CdtrAcct), false, false);
            Write26_Item(@"RmtInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf)o.@RmtInf), false, false);
            WriteEndElement(o);
        }

        void Write14_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write13_Item(@"FinInstnId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId)o.@FinInstnId), false, false);
            WriteEndElement(o);
        }

        void Write12_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write11_Item(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID)o.@Id), false, false);
            WriteElementString(@"Ccy", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Ccy));
            WriteEndElement(o);
        }

        void Write10_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInfDbtr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Nm", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Nm));
            Write9_Item(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrID)o.@Id), false, false);
            WriteEndElement(o);
        }

        void Write36_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Id));
            WriteEndElement(o);
        }

        void Write35_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write2_Item(@"Othr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr)o.@Othr), false, false);
            WriteEndElement(o);
        }

        void Write2_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Id));
            WriteEndElement(o);
        }

        void Write34_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write3_Item(@"OrgId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId)o.@OrgId), false, false);
            WriteEndElement(o);
        }

        void Write3_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write2_Item(@"Othr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr)o.@Othr), false, false);
            WriteEndElement(o);
        }

        void Write33_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPty", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Nm", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Nm));
            Write4_Item(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID)o.@Id), false, false);
            WriteEndElement(o);
        }

        void Write4_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write3_Item(@"OrgId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId)o.@OrgId), false, false);
            WriteEndElement(o);
        }

        void Write32_DocumentCstmrCdtTrfInitnGrpHdr(string n, string ns, global::DocumentCstmrCdtTrfInitnGrpHdr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnGrpHdr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitnGrpHdr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"MsgId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@MsgId));
            WriteElementStringRaw(@"CreDtTm", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", FromDateTime(((global::System.DateTime)o.@CreDtTm)));
            WriteElementStringRaw(@"NbOfTxs", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", System.Xml.XmlConvert.ToString((global::System.SByte)((global::System.SByte)o.@NbOfTxs)));
            Write5_Item(@"InitgPty", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty)o.@InitgPty), false, false);
            WriteEndElement(o);
        }

        void Write5_Item(string n, string ns, global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"Nm", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@Nm));
            Write4_Item(@"Id", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID)o.@Id), false, false);
            WriteEndElement(o);
        }

        void Write31_DocumentCstmrCdtTrfInitn(string n, string ns, global::DocumentCstmrCdtTrfInitn o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitn)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(@"DocumentCstmrCdtTrfInitn", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write6_DocumentCstmrCdtTrfInitnGrpHdr(@"GrpHdr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnGrpHdr)o.@GrpHdr), false, false);
            Write28_DocumentCstmrCdtTrfInitnPmtInf(@"PmtInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInf)o.@PmtInf), false, false);
            WriteEndElement(o);
        }

        void Write28_DocumentCstmrCdtTrfInitnPmtInf(string n, string ns, global::DocumentCstmrCdtTrfInitnPmtInf o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnPmtInf)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"PmtInfId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@PmtInfId));
            WriteElementString(@"PmtMtd", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@PmtMtd));
            WriteElementStringRaw(@"ReqdExctnDt", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", FromDate(((global::System.DateTime)o.@ReqdExctnDt)));
            Write10_Item(@"Dbtr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtr)o.@Dbtr), false, false);
            Write12_Item(@"DbtrAcct", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct)o.@DbtrAcct), false, false);
            Write14_Item(@"DbtrAgt", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt)o.@DbtrAgt), false, false);
            {
                global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[] a = (global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[])o.@CdtTrfTxInf;
                if (a != null) {
                    for (int ia = 0; ia < a.Length; ia++) {
                        Write27_Item(@"CdtTrfTxInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf)a[ia]), false, false);
                    }
                }
            }
            WriteEndElement(o);
        }

        void Write6_DocumentCstmrCdtTrfInitnGrpHdr(string n, string ns, global::DocumentCstmrCdtTrfInitnGrpHdr o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitnGrpHdr)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            WriteElementString(@"MsgId", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::System.String)o.@MsgId));
            WriteElementStringRaw(@"CreDtTm", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", FromDateTime(((global::System.DateTime)o.@CreDtTm)));
            WriteElementStringRaw(@"NbOfTxs", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", System.Xml.XmlConvert.ToString((global::System.SByte)((global::System.SByte)o.@NbOfTxs)));
            Write5_Item(@"InitgPty", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty)o.@InitgPty), false, false);
            WriteEndElement(o);
        }

        void Write30_Document(string n, string ns, global::Document o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::Document)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write29_DocumentCstmrCdtTrfInitn(@"CstmrCdtTrfInitn", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitn)o.@CstmrCdtTrfInitn), false, false);
            WriteEndElement(o);
        }

        void Write29_DocumentCstmrCdtTrfInitn(string n, string ns, global::DocumentCstmrCdtTrfInitn o, bool isNullable, bool needType) {
            if ((object)o == null) {
                if (isNullable) WriteNullTagLiteral(n, ns);
                return;
            }
            if (!needType) {
                System.Type t = o.GetType();
                if (t == typeof(global::DocumentCstmrCdtTrfInitn)) {
                }
                else {
                    throw CreateUnknownTypeException(o);
                }
            }
            WriteStartElement(n, ns, o, false, null);
            if (needType) WriteXsiType(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            Write6_DocumentCstmrCdtTrfInitnGrpHdr(@"GrpHdr", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnGrpHdr)o.@GrpHdr), false, false);
            Write28_DocumentCstmrCdtTrfInitnPmtInf(@"PmtInf", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03", ((global::DocumentCstmrCdtTrfInitnPmtInf)o.@PmtInf), false, false);
            WriteEndElement(o);
        }

        protected override void InitCallbacks() {
        }
    }

    public class XmlSerializationReader1 : System.Xml.Serialization.XmlSerializationReader {

        public object Read59_Document() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id1_Document && (object) Reader.NamespaceURI == (object)id2_Item)) {
                        o = Read30_Document(false, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Document");
            }
            return (object)o;
        }

        public object Read60_DocumentCstmrCdtTrfInitn() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id3_DocumentCstmrCdtTrfInitn && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read31_DocumentCstmrCdtTrfInitn(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitn");
            }
            return (object)o;
        }

        public object Read61_DocumentCstmrCdtTrfInitnGrpHdr() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id5_DocumentCstmrCdtTrfInitnGrpHdr && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read32_DocumentCstmrCdtTrfInitnGrpHdr(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnGrpHdr");
            }
            return (object)o;
        }

        public object Read62_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id6_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read33_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnGrpHdrInitgPty");
            }
            return (object)o;
        }

        public object Read63_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id7_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read34_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID");
            }
            return (object)o;
        }

        public object Read64_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id8_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read35_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId");
            }
            return (object)o;
        }

        public object Read65_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id9_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read36_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr");
            }
            return (object)o;
        }

        public object Read66_DocumentCstmrCdtTrfInitnPmtInf() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id10_DocumentCstmrCdtTrfInitnPmtInf && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read37_DocumentCstmrCdtTrfInitnPmtInf(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInf");
            }
            return (object)o;
        }

        public object Read67_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id11_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read38_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfDbtr");
            }
            return (object)o;
        }

        public object Read68_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id12_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read39_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfDbtrID");
            }
            return (object)o;
        }

        public object Read69_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id13_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read40_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId");
            }
            return (object)o;
        }

        public object Read70_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id14_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read41_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr");
            }
            return (object)o;
        }

        public object Read71_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id15_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read42_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfDbtrAcct");
            }
            return (object)o;
        }

        public object Read72_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id16_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read43_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID");
            }
            return (object)o;
        }

        public object Read73_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id17_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read44_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfDbtrAgt");
            }
            return (object)o;
        }

        public object Read74_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id18_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read45_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId");
            }
            return (object)o;
        }

        public object Read75_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id19_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read46_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf");
            }
            return (object)o;
        }

        public object Read76_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id20_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read47_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId");
            }
            return (object)o;
        }

        public object Read77_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id21_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read48_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf");
            }
            return (object)o;
        }

        public object Read78_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id22_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read49_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl");
            }
            return (object)o;
        }

        public object Read79_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id23_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read50_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt");
            }
            return (object)o;
        }

        public object Read80_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id24_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read51_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt");
            }
            return (object)o;
        }

        public object Read81_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id25_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read52_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr");
            }
            return (object)o;
        }

        public object Read82_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id26_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read53_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID");
            }
            return (object)o;
        }

        public object Read83_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id27_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read54_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId");
            }
            return (object)o;
        }

        public object Read84_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id28_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read55_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr");
            }
            return (object)o;
        }

        public object Read85_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id29_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read56_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct");
            }
            return (object)o;
        }

        public object Read86_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id30_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read57_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID");
            }
            return (object)o;
        }

        public object Read87_Item() {
            object o = null;
            Reader.MoveToContent();
            if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                do {
                    if (((object) Reader.LocalName == (object)id31_Item && (object) Reader.NamespaceURI == (object)id4_Item)) {
                        o = Read58_Item(true, true);
                        break;
                    }
                    throw CreateUnknownNodeException();
                } while (false);
            }
            else {
                UnknownNode(null, @":DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf");
            }
            return (object)o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf Read58_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id31_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id32_Ustrd && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Ustrd = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Ustrd");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Ustrd");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID Read57_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id30_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id33_IBAN && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@IBAN = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:IBAN");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:IBAN");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct Read56_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id29_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Id = Read24_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID Read24_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id33_IBAN && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@IBAN = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:IBAN");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:IBAN");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr Read55_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id28_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Id = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId Read54_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id27_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id35_Othr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Othr = Read20_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr Read20_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Id = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID Read53_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id26_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id36_PrvtId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@PrvtId = Read21_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PrvtId");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PrvtId");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId Read21_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id35_Othr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Othr = Read20_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr Read52_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id25_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id37_Nm && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Nm = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Id = Read22_Item(false, true);
                            paramsRead[1] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID Read22_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id36_PrvtId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@PrvtId = Read21_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PrvtId");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PrvtId");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt Read51_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id24_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id38_Ccy && (object) Reader.NamespaceURI == (object)id4_Item)) {
                    o.@Ccy = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":Ccy");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    o.@Value = System.Xml.XmlConvert.ToSingle(Reader.ReadString());
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt Read50_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id23_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id39_InstdAmt && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@InstdAmt = Read18_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:InstdAmt");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:InstdAmt");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt Read18_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!paramsRead[0] && ((object) Reader.LocalName == (object)id38_Ccy && (object) Reader.NamespaceURI == (object)id4_Item)) {
                    o.@Ccy = Reader.Value;
                    paramsRead[0] = true;
                }
                else if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o, @":Ccy");
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                string tmp = null;
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    UnknownNode((object)o, @"");
                }
                else if (Reader.NodeType == System.Xml.XmlNodeType.Text || 
                Reader.NodeType == System.Xml.XmlNodeType.CDATA || 
                Reader.NodeType == System.Xml.XmlNodeType.Whitespace || 
                Reader.NodeType == System.Xml.XmlNodeType.SignificantWhitespace) {
                    o.@Value = System.Xml.XmlConvert.ToSingle(Reader.ReadString());
                }
                else {
                    UnknownNode((object)o, @"");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl Read49_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id22_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id40_Cd && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Cd = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Cd");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Cd");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf Read48_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id21_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id41_SvcLvl && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@SvcLvl = Read16_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:SvcLvl");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:SvcLvl");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl Read16_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id40_Cd && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Cd = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Cd");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Cd");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId Read47_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id20_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id42_EndToEndId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@EndToEndId = System.Xml.XmlConvert.ToInt16(Reader.ReadElementString());
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:EndToEndId");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:EndToEndId");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf Read46_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id19_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf();
            System.Span<bool> paramsRead = stackalloc bool[6];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id43_PmtId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@PmtId = Read15_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id44_PmtTpInf && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@PmtTpInf = Read17_Item(false, true);
                            paramsRead[1] = true;
                            break;
                        }
                        if (!paramsRead[2] && ((object) Reader.LocalName == (object)id45_Amt && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Amt = Read19_Item(false, true);
                            paramsRead[2] = true;
                            break;
                        }
                        if (!paramsRead[3] && ((object) Reader.LocalName == (object)id46_Cdtr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Cdtr = Read23_Item(false, true);
                            paramsRead[3] = true;
                            break;
                        }
                        if (!paramsRead[4] && ((object) Reader.LocalName == (object)id47_CdtrAcct && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@CdtrAcct = Read25_Item(false, true);
                            paramsRead[4] = true;
                            break;
                        }
                        if (!paramsRead[5] && ((object) Reader.LocalName == (object)id48_RmtInf && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@RmtInf = Read26_Item(false, true);
                            paramsRead[5] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtTpInf, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Amt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Cdtr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CdtrAcct, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:RmtInf");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtTpInf, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Amt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Cdtr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CdtrAcct, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:RmtInf");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf Read26_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id32_Ustrd && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Ustrd = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Ustrd");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Ustrd");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct Read25_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Id = Read24_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr Read23_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id37_Nm && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Nm = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Id = Read22_Item(false, true);
                            paramsRead[1] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt Read19_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id39_InstdAmt && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@InstdAmt = Read18_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:InstdAmt");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:InstdAmt");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf Read17_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id41_SvcLvl && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@SvcLvl = Read16_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:SvcLvl");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:SvcLvl");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId Read15_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id42_EndToEndId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@EndToEndId = System.Xml.XmlConvert.ToInt16(Reader.ReadElementString());
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:EndToEndId");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:EndToEndId");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId Read45_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id18_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id49_BIC && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@BIC = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:BIC");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:BIC");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt Read44_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id17_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id50_FinInstnId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@FinInstnId = Read13_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:FinInstnId");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:FinInstnId");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId Read13_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id49_BIC && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@BIC = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:BIC");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:BIC");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID Read43_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id16_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id33_IBAN && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@IBAN = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:IBAN");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:IBAN");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct Read42_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id15_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Id = Read11_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id38_Ccy && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Ccy = Reader.ReadElementString();
                            }
                            paramsRead[1] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Ccy");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Ccy");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID Read11_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id33_IBAN && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@IBAN = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:IBAN");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:IBAN");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr Read41_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id14_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Id = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId Read40_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id13_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id35_Othr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Othr = Read7_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr Read7_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Id = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrID Read39_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id12_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrID o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrID();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id51_OrgId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@OrgId = Read8_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:OrgId");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:OrgId");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId Read8_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id35_Othr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Othr = Read7_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtr Read38_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id11_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtr o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtr();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id37_Nm && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Nm = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Id = Read9_Item(false, true);
                            paramsRead[1] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrID Read9_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrID o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrID();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id51_OrgId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@OrgId = Read8_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:OrgId");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:OrgId");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInf Read37_DocumentCstmrCdtTrfInitnPmtInf(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id10_DocumentCstmrCdtTrfInitnPmtInf && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInf o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInf();
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[] a_6 = null;
            int ca_6 = 0;
            System.Span<bool> paramsRead = stackalloc bool[7];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                o.@CdtTrfTxInf = (global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[])ShrinkArray(a_6, ca_6, typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf), true);
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id52_PmtInfId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@PmtInfId = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id53_PmtMtd && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@PmtMtd = Reader.ReadElementString();
                            }
                            paramsRead[1] = true;
                            break;
                        }
                        if (!paramsRead[2] && ((object) Reader.LocalName == (object)id54_ReqdExctnDt && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@ReqdExctnDt = ToDate(Reader.ReadElementString());
                            }
                            paramsRead[2] = true;
                            break;
                        }
                        if (!paramsRead[3] && ((object) Reader.LocalName == (object)id55_Dbtr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Dbtr = Read10_Item(false, true);
                            paramsRead[3] = true;
                            break;
                        }
                        if (!paramsRead[4] && ((object) Reader.LocalName == (object)id56_DbtrAcct && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@DbtrAcct = Read12_Item(false, true);
                            paramsRead[4] = true;
                            break;
                        }
                        if (!paramsRead[5] && ((object) Reader.LocalName == (object)id57_DbtrAgt && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@DbtrAgt = Read14_Item(false, true);
                            paramsRead[5] = true;
                            break;
                        }
                        if (((object) Reader.LocalName == (object)id58_CdtTrfTxInf && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            a_6 = (global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[])EnsureArrayIndex(a_6, ca_6, typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf));a_6[ca_6++] = Read27_Item(false, true);
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtInfId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtMtd, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:ReqdExctnDt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Dbtr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:DbtrAcct, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:DbtrAgt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CdtTrfTxInf");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtInfId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtMtd, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:ReqdExctnDt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Dbtr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:DbtrAcct, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:DbtrAgt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CdtTrfTxInf");
                }
                Reader.MoveToContent();
            }
            o.@CdtTrfTxInf = (global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[])ShrinkArray(a_6, ca_6, typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf), true);
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf Read27_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf();
            System.Span<bool> paramsRead = stackalloc bool[6];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id43_PmtId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@PmtId = Read15_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id44_PmtTpInf && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@PmtTpInf = Read17_Item(false, true);
                            paramsRead[1] = true;
                            break;
                        }
                        if (!paramsRead[2] && ((object) Reader.LocalName == (object)id45_Amt && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Amt = Read19_Item(false, true);
                            paramsRead[2] = true;
                            break;
                        }
                        if (!paramsRead[3] && ((object) Reader.LocalName == (object)id46_Cdtr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Cdtr = Read23_Item(false, true);
                            paramsRead[3] = true;
                            break;
                        }
                        if (!paramsRead[4] && ((object) Reader.LocalName == (object)id47_CdtrAcct && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@CdtrAcct = Read25_Item(false, true);
                            paramsRead[4] = true;
                            break;
                        }
                        if (!paramsRead[5] && ((object) Reader.LocalName == (object)id48_RmtInf && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@RmtInf = Read26_Item(false, true);
                            paramsRead[5] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtTpInf, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Amt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Cdtr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CdtrAcct, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:RmtInf");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtTpInf, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Amt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Cdtr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CdtrAcct, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:RmtInf");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt Read14_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id50_FinInstnId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@FinInstnId = Read13_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:FinInstnId");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:FinInstnId");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct Read12_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Id = Read11_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id38_Ccy && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Ccy = Reader.ReadElementString();
                            }
                            paramsRead[1] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Ccy");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Ccy");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInfDbtr Read10_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInfDbtr o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInfDbtr();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id37_Nm && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Nm = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Id = Read9_Item(false, true);
                            paramsRead[1] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr Read36_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id9_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr o;
            o = new global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Id = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId Read35_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id8_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId o;
            o = new global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id35_Othr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Othr = Read2_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr Read2_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr o;
            o = new global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Id = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID Read34_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id7_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID o;
            o = new global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id51_OrgId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@OrgId = Read3_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:OrgId");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:OrgId");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId Read3_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId o;
            o = new global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id35_Othr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Othr = Read2_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Othr");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty Read33_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id6_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty o;
            o = new global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id37_Nm && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Nm = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Id = Read4_Item(false, true);
                            paramsRead[1] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID Read4_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID o;
            o = new global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id51_OrgId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@OrgId = Read3_Item(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:OrgId");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:OrgId");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnGrpHdr Read32_DocumentCstmrCdtTrfInitnGrpHdr(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id5_DocumentCstmrCdtTrfInitnGrpHdr && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnGrpHdr o;
            o = new global::DocumentCstmrCdtTrfInitnGrpHdr();
            System.Span<bool> paramsRead = stackalloc bool[4];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id59_MsgId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@MsgId = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id60_CreDtTm && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@CreDtTm = ToDateTime(Reader.ReadElementString());
                            }
                            paramsRead[1] = true;
                            break;
                        }
                        if (!paramsRead[2] && ((object) Reader.LocalName == (object)id61_NbOfTxs && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@NbOfTxs = System.Xml.XmlConvert.ToSByte(Reader.ReadElementString());
                            }
                            paramsRead[2] = true;
                            break;
                        }
                        if (!paramsRead[3] && ((object) Reader.LocalName == (object)id62_InitgPty && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@InitgPty = Read5_Item(false, true);
                            paramsRead[3] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:MsgId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CreDtTm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:NbOfTxs, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:InitgPty");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:MsgId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CreDtTm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:NbOfTxs, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:InitgPty");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty Read5_Item(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty o;
            o = new global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id37_Nm && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@Nm = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id34_Id && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Id = Read4_Item(false, true);
                            paramsRead[1] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Nm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Id");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitn Read31_DocumentCstmrCdtTrfInitn(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id3_DocumentCstmrCdtTrfInitn && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitn o;
            o = new global::DocumentCstmrCdtTrfInitn();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id63_GrpHdr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@GrpHdr = Read6_DocumentCstmrCdtTrfInitnGrpHdr(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id64_PmtInf && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@PmtInf = Read28_DocumentCstmrCdtTrfInitnPmtInf(false, true);
                            paramsRead[1] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:GrpHdr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtInf");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:GrpHdr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtInf");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnPmtInf Read28_DocumentCstmrCdtTrfInitnPmtInf(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnPmtInf o;
            o = new global::DocumentCstmrCdtTrfInitnPmtInf();
            global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[] a_6 = null;
            int ca_6 = 0;
            System.Span<bool> paramsRead = stackalloc bool[7];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                o.@CdtTrfTxInf = (global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[])ShrinkArray(a_6, ca_6, typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf), true);
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id52_PmtInfId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@PmtInfId = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id53_PmtMtd && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@PmtMtd = Reader.ReadElementString();
                            }
                            paramsRead[1] = true;
                            break;
                        }
                        if (!paramsRead[2] && ((object) Reader.LocalName == (object)id54_ReqdExctnDt && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@ReqdExctnDt = ToDate(Reader.ReadElementString());
                            }
                            paramsRead[2] = true;
                            break;
                        }
                        if (!paramsRead[3] && ((object) Reader.LocalName == (object)id55_Dbtr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@Dbtr = Read10_Item(false, true);
                            paramsRead[3] = true;
                            break;
                        }
                        if (!paramsRead[4] && ((object) Reader.LocalName == (object)id56_DbtrAcct && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@DbtrAcct = Read12_Item(false, true);
                            paramsRead[4] = true;
                            break;
                        }
                        if (!paramsRead[5] && ((object) Reader.LocalName == (object)id57_DbtrAgt && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@DbtrAgt = Read14_Item(false, true);
                            paramsRead[5] = true;
                            break;
                        }
                        if (((object) Reader.LocalName == (object)id58_CdtTrfTxInf && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            a_6 = (global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[])EnsureArrayIndex(a_6, ca_6, typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf));a_6[ca_6++] = Read27_Item(false, true);
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtInfId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtMtd, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:ReqdExctnDt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Dbtr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:DbtrAcct, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:DbtrAgt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CdtTrfTxInf");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtInfId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtMtd, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:ReqdExctnDt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:Dbtr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:DbtrAcct, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:DbtrAgt, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CdtTrfTxInf");
                }
                Reader.MoveToContent();
            }
            o.@CdtTrfTxInf = (global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf[])ShrinkArray(a_6, ca_6, typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf), true);
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitnGrpHdr Read6_DocumentCstmrCdtTrfInitnGrpHdr(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitnGrpHdr o;
            o = new global::DocumentCstmrCdtTrfInitnGrpHdr();
            System.Span<bool> paramsRead = stackalloc bool[4];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id59_MsgId && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@MsgId = Reader.ReadElementString();
                            }
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id60_CreDtTm && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@CreDtTm = ToDateTime(Reader.ReadElementString());
                            }
                            paramsRead[1] = true;
                            break;
                        }
                        if (!paramsRead[2] && ((object) Reader.LocalName == (object)id61_NbOfTxs && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            {
                                o.@NbOfTxs = System.Xml.XmlConvert.ToSByte(Reader.ReadElementString());
                            }
                            paramsRead[2] = true;
                            break;
                        }
                        if (!paramsRead[3] && ((object) Reader.LocalName == (object)id62_InitgPty && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@InitgPty = Read5_Item(false, true);
                            paramsRead[3] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:MsgId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CreDtTm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:NbOfTxs, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:InitgPty");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:MsgId, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CreDtTm, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:NbOfTxs, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:InitgPty");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::Document Read30_Document(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::Document o;
            o = new global::Document();
            System.Span<bool> paramsRead = stackalloc bool[1];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id65_CstmrCdtTrfInitn && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@CstmrCdtTrfInitn = Read29_DocumentCstmrCdtTrfInitn(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CstmrCdtTrfInitn");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:CstmrCdtTrfInitn");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        global::DocumentCstmrCdtTrfInitn Read29_DocumentCstmrCdtTrfInitn(bool isNullable, bool checkType) {
            System.Xml.XmlQualifiedName xsiType = checkType ? GetXsiType() : null;
            bool isNull = false;
            if (isNullable) isNull = ReadNull();
            if (checkType) {
            if (xsiType == null || ((object) ((System.Xml.XmlQualifiedName)xsiType).Name == (object)id4_Item && (object) ((System.Xml.XmlQualifiedName)xsiType).Namespace == (object)id2_Item)) {
            }
            else {
                throw CreateUnknownTypeException((System.Xml.XmlQualifiedName)xsiType);
            }
            }
            if (isNull) return null;
            global::DocumentCstmrCdtTrfInitn o;
            o = new global::DocumentCstmrCdtTrfInitn();
            System.Span<bool> paramsRead = stackalloc bool[2];
            while (Reader.MoveToNextAttribute()) {
                if (!IsXmlnsAttribute(Reader.Name)) {
                    UnknownNode((object)o);
                }
            }
            Reader.MoveToElement();
            if (Reader.IsEmptyElement) {
                Reader.Skip();
                return o;
            }
            Reader.ReadStartElement();
            Reader.MoveToContent();
            while (Reader.NodeType != System.Xml.XmlNodeType.EndElement && Reader.NodeType != System.Xml.XmlNodeType.None) {
                if (Reader.NodeType == System.Xml.XmlNodeType.Element) {
                    do {
                        if (!paramsRead[0] && ((object) Reader.LocalName == (object)id63_GrpHdr && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@GrpHdr = Read6_DocumentCstmrCdtTrfInitnGrpHdr(false, true);
                            paramsRead[0] = true;
                            break;
                        }
                        if (!paramsRead[1] && ((object) Reader.LocalName == (object)id64_PmtInf && (object) Reader.NamespaceURI == (object)id2_Item)) {
                            o.@PmtInf = Read28_DocumentCstmrCdtTrfInitnPmtInf(false, true);
                            paramsRead[1] = true;
                            break;
                        }
                        UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:GrpHdr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtInf");
                    } while (false);
                }
                else {
                    UnknownNode((object)o, @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:GrpHdr, urn:iso:std:iso:20022:tech:xsd:pain.001.001.03:PmtInf");
                }
                Reader.MoveToContent();
            }
            ReadEndElement();
            return o;
        }

        protected override void InitCallbacks() {
        }

        string id8_Item;
        string id24_Item;
        string id45_Amt;
        string id61_NbOfTxs;
        string id59_MsgId;
        string id44_PmtTpInf;
        string id38_Ccy;
        string id52_PmtInfId;
        string id37_Nm;
        string id33_IBAN;
        string id55_Dbtr;
        string id50_FinInstnId;
        string id17_Item;
        string id25_Item;
        string id30_Item;
        string id1_Document;
        string id57_DbtrAgt;
        string id9_Item;
        string id41_SvcLvl;
        string id27_Item;
        string id63_GrpHdr;
        string id16_Item;
        string id28_Item;
        string id36_PrvtId;
        string id62_InitgPty;
        string id40_Cd;
        string id34_Id;
        string id56_DbtrAcct;
        string id31_Item;
        string id65_CstmrCdtTrfInitn;
        string id48_RmtInf;
        string id53_PmtMtd;
        string id49_BIC;
        string id2_Item;
        string id42_EndToEndId;
        string id35_Othr;
        string id58_CdtTrfTxInf;
        string id51_OrgId;
        string id4_Item;
        string id21_Item;
        string id6_Item;
        string id32_Ustrd;
        string id29_Item;
        string id11_Item;
        string id18_Item;
        string id20_Item;
        string id26_Item;
        string id23_Item;
        string id54_ReqdExctnDt;
        string id64_PmtInf;
        string id7_Item;
        string id47_CdtrAcct;
        string id10_DocumentCstmrCdtTrfInitnPmtInf;
        string id12_Item;
        string id22_Item;
        string id5_DocumentCstmrCdtTrfInitnGrpHdr;
        string id19_Item;
        string id15_Item;
        string id14_Item;
        string id46_Cdtr;
        string id3_DocumentCstmrCdtTrfInitn;
        string id13_Item;
        string id43_PmtId;
        string id60_CreDtTm;
        string id39_InstdAmt;

        protected override void InitIDs() {
            id8_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId");
            id24_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt");
            id45_Amt = Reader.NameTable.Add(@"Amt");
            id61_NbOfTxs = Reader.NameTable.Add(@"NbOfTxs");
            id59_MsgId = Reader.NameTable.Add(@"MsgId");
            id44_PmtTpInf = Reader.NameTable.Add(@"PmtTpInf");
            id38_Ccy = Reader.NameTable.Add(@"Ccy");
            id52_PmtInfId = Reader.NameTable.Add(@"PmtInfId");
            id37_Nm = Reader.NameTable.Add(@"Nm");
            id33_IBAN = Reader.NameTable.Add(@"IBAN");
            id55_Dbtr = Reader.NameTable.Add(@"Dbtr");
            id50_FinInstnId = Reader.NameTable.Add(@"FinInstnId");
            id17_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgt");
            id25_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr");
            id30_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID");
            id1_Document = Reader.NameTable.Add(@"Document");
            id57_DbtrAgt = Reader.NameTable.Add(@"DbtrAgt");
            id9_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr");
            id41_SvcLvl = Reader.NameTable.Add(@"SvcLvl");
            id27_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId");
            id63_GrpHdr = Reader.NameTable.Add(@"GrpHdr");
            id16_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID");
            id28_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr");
            id36_PrvtId = Reader.NameTable.Add(@"PrvtId");
            id62_InitgPty = Reader.NameTable.Add(@"InitgPty");
            id40_Cd = Reader.NameTable.Add(@"Cd");
            id34_Id = Reader.NameTable.Add(@"Id");
            id56_DbtrAcct = Reader.NameTable.Add(@"DbtrAcct");
            id31_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf");
            id65_CstmrCdtTrfInitn = Reader.NameTable.Add(@"CstmrCdtTrfInitn");
            id48_RmtInf = Reader.NameTable.Add(@"RmtInf");
            id53_PmtMtd = Reader.NameTable.Add(@"PmtMtd");
            id49_BIC = Reader.NameTable.Add(@"BIC");
            id2_Item = Reader.NameTable.Add(@"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
            id42_EndToEndId = Reader.NameTable.Add(@"EndToEndId");
            id35_Othr = Reader.NameTable.Add(@"Othr");
            id58_CdtTrfTxInf = Reader.NameTable.Add(@"CdtTrfTxInf");
            id51_OrgId = Reader.NameTable.Add(@"OrgId");
            id4_Item = Reader.NameTable.Add(@"");
            id21_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf");
            id6_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPty");
            id32_Ustrd = Reader.NameTable.Add(@"Ustrd");
            id29_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct");
            id11_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtr");
            id18_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId");
            id20_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId");
            id26_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID");
            id23_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt");
            id54_ReqdExctnDt = Reader.NameTable.Add(@"ReqdExctnDt");
            id64_PmtInf = Reader.NameTable.Add(@"PmtInf");
            id7_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID");
            id47_CdtrAcct = Reader.NameTable.Add(@"CdtrAcct");
            id10_DocumentCstmrCdtTrfInitnPmtInf = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInf");
            id12_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrID");
            id22_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl");
            id5_DocumentCstmrCdtTrfInitnGrpHdr = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnGrpHdr");
            id19_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf");
            id15_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcct");
            id14_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr");
            id46_Cdtr = Reader.NameTable.Add(@"Cdtr");
            id3_DocumentCstmrCdtTrfInitn = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitn");
            id13_Item = Reader.NameTable.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId");
            id43_PmtId = Reader.NameTable.Add(@"PmtId");
            id60_CreDtTm = Reader.NameTable.Add(@"CreDtTm");
            id39_InstdAmt = Reader.NameTable.Add(@"InstdAmt");
        }
    }

    public abstract class XmlSerializer1 : System.Xml.Serialization.XmlSerializer {
        protected override System.Xml.Serialization.XmlSerializationReader CreateReader() {
            return new XmlSerializationReader1();
        }
        protected override System.Xml.Serialization.XmlSerializationWriter CreateWriter() {
            return new XmlSerializationWriter1();
        }
    }

    public sealed class DocumentSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"Document", @"urn:iso:std:iso:20022:tech:xsd:pain.001.001.03");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write59_Document(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read59_Document();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitn", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write60_DocumentCstmrCdtTrfInitn(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read60_DocumentCstmrCdtTrfInitn();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnGrpHdrSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnGrpHdr", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write61_DocumentCstmrCdtTrfInitnGrpHdr(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read61_DocumentCstmrCdtTrfInitnGrpHdr();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnGrpHdrInitgPtySerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPty", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write62_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read62_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write63_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read63_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write64_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read64_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthrSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write65_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read65_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInf", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write66_DocumentCstmrCdtTrfInitnPmtInf(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read66_DocumentCstmrCdtTrfInitnPmtInf();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfDbtrSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfDbtr", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write67_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read67_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfDbtrIDSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfDbtrID", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write68_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read68_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write69_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read69_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthrSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write70_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read70_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfDbtrAcctSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcct", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write71_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read71_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfDbtrAcctIDSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write72_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read72_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfDbtrAgtSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgt", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write73_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read73_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnIdSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write74_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read74_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write75_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read75_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtIdSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write76_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read76_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write77_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read77_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvlSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write78_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read78_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write79_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read79_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmtSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write80_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read80_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write81_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read81_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write82_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read82_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write83_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read83_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthrSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write84_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read84_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write85_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read85_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctIDSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write86_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read86_Item();
        }
    }

    public sealed class DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInfSerializer : XmlSerializer1 {

        public override System.Boolean CanDeserialize(System.Xml.XmlReader xmlReader) {
            return xmlReader.IsStartElement(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf", @"");
        }

        protected override void Serialize(object objectToSerialize, System.Xml.Serialization.XmlSerializationWriter writer) {
            ((XmlSerializationWriter1)writer).Write87_Item(objectToSerialize);
        }

        protected override object Deserialize(System.Xml.Serialization.XmlSerializationReader reader) {
            return ((XmlSerializationReader1)reader).Read87_Item();
        }
    }

    public class XmlSerializerContract : global::System.Xml.Serialization.XmlSerializerImplementation {
        public override global::System.Xml.Serialization.XmlSerializationReader Reader { get { return new XmlSerializationReader1(); } }
        public override global::System.Xml.Serialization.XmlSerializationWriter Writer { get { return new XmlSerializationWriter1(); } }
        System.Collections.Hashtable readMethods = null;
        public override System.Collections.Hashtable ReadMethods {
            get {
                if (readMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"Document:urn:iso:std:iso:20022:tech:xsd:pain.001.001.03::False:"] = @"Read59_Document";
                    _tmp[@"DocumentCstmrCdtTrfInitn::"] = @"Read60_DocumentCstmrCdtTrfInitn";
                    _tmp[@"DocumentCstmrCdtTrfInitnGrpHdr::"] = @"Read61_DocumentCstmrCdtTrfInitnGrpHdr";
                    _tmp[@"DocumentCstmrCdtTrfInitnGrpHdrInitgPty::"] = @"Read62_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID::"] = @"Read63_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId::"] = @"Read64_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr::"] = @"Read65_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInf::"] = @"Read66_DocumentCstmrCdtTrfInitnPmtInf";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtr::"] = @"Read67_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrID::"] = @"Read68_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId::"] = @"Read69_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr::"] = @"Read70_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcct::"] = @"Read71_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID::"] = @"Read72_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgt::"] = @"Read73_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId::"] = @"Read74_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf::"] = @"Read75_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId::"] = @"Read76_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf::"] = @"Read77_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl::"] = @"Read78_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt::"] = @"Read79_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt::"] = @"Read80_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr::"] = @"Read81_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID::"] = @"Read82_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId::"] = @"Read83_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr::"] = @"Read84_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct::"] = @"Read85_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID::"] = @"Read86_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf::"] = @"Read87_Item";
                    if (readMethods == null) readMethods = _tmp;
                }
                return readMethods;
            }
        }
        System.Collections.Hashtable writeMethods = null;
        public override System.Collections.Hashtable WriteMethods {
            get {
                if (writeMethods == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp[@"Document:urn:iso:std:iso:20022:tech:xsd:pain.001.001.03::False:"] = @"Write59_Document";
                    _tmp[@"DocumentCstmrCdtTrfInitn::"] = @"Write60_DocumentCstmrCdtTrfInitn";
                    _tmp[@"DocumentCstmrCdtTrfInitnGrpHdr::"] = @"Write61_DocumentCstmrCdtTrfInitnGrpHdr";
                    _tmp[@"DocumentCstmrCdtTrfInitnGrpHdrInitgPty::"] = @"Write62_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID::"] = @"Write63_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId::"] = @"Write64_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr::"] = @"Write65_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInf::"] = @"Write66_DocumentCstmrCdtTrfInitnPmtInf";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtr::"] = @"Write67_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrID::"] = @"Write68_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId::"] = @"Write69_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr::"] = @"Write70_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcct::"] = @"Write71_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID::"] = @"Write72_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgt::"] = @"Write73_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId::"] = @"Write74_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf::"] = @"Write75_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId::"] = @"Write76_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf::"] = @"Write77_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl::"] = @"Write78_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt::"] = @"Write79_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt::"] = @"Write80_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr::"] = @"Write81_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID::"] = @"Write82_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId::"] = @"Write83_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr::"] = @"Write84_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct::"] = @"Write85_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID::"] = @"Write86_Item";
                    _tmp[@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf::"] = @"Write87_Item";
                    if (writeMethods == null) writeMethods = _tmp;
                }
                return writeMethods;
            }
        }
        System.Collections.Hashtable typedSerializers = null;
        public override System.Collections.Hashtable TypedSerializers {
            get {
                if (typedSerializers == null) {
                    System.Collections.Hashtable _tmp = new System.Collections.Hashtable();
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtr::", new DocumentCstmrCdtTrfInitnPmtInfDbtrSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId::", new DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId::", new DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnIdSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcct::", new DocumentCstmrCdtTrfInitnPmtInfDbtrAcctSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInfSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctIDSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDSerializer());
                    _tmp.Add(@"Document:urn:iso:std:iso:20022:tech:xsd:pain.001.001.03::False:", new DocumentSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmtSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPty::", new DocumentCstmrCdtTrfInitnGrpHdrInitgPtySerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr::", new DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthrSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID::", new DocumentCstmrCdtTrfInitnPmtInfDbtrAcctIDSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrID::", new DocumentCstmrCdtTrfInitnPmtInfDbtrIDSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr::", new DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthrSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthrSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId::", new DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitn::", new DocumentCstmrCdtTrfInitnSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnGrpHdr::", new DocumentCstmrCdtTrfInitnGrpHdrSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID::", new DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtIdSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvlSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInf::", new DocumentCstmrCdtTrfInitnPmtInfSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfDbtrAgt::", new DocumentCstmrCdtTrfInitnPmtInfDbtrAgtSerializer());
                    _tmp.Add(@"DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr::", new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrSerializer());
                    if (typedSerializers == null) typedSerializers = _tmp;
                }
                return typedSerializers;
            }
        }
        public override System.Boolean CanSerialize(System.Type type) {
            if (type == typeof(global::Document)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitn)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnGrpHdr)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInf)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtr)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrID)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID)) return true;
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf)) return true;
            return false;
        }
        public override System.Xml.Serialization.XmlSerializer GetSerializer(System.Type type) {
            if (type == typeof(global::Document)) return new DocumentSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitn)) return new DocumentCstmrCdtTrfInitnSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnGrpHdr)) return new DocumentCstmrCdtTrfInitnGrpHdrSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPty)) return new DocumentCstmrCdtTrfInitnGrpHdrInitgPtySerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyID)) return new DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgId)) return new DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthr)) return new DocumentCstmrCdtTrfInitnGrpHdrInitgPtyIDOrgIdOthrSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInf)) return new DocumentCstmrCdtTrfInitnPmtInfSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtr)) return new DocumentCstmrCdtTrfInitnPmtInfDbtrSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrID)) return new DocumentCstmrCdtTrfInitnPmtInfDbtrIDSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgId)) return new DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthr)) return new DocumentCstmrCdtTrfInitnPmtInfDbtrIDOrgIdOthrSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcct)) return new DocumentCstmrCdtTrfInitnPmtInfDbtrAcctSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAcctID)) return new DocumentCstmrCdtTrfInitnPmtInfDbtrAcctIDSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgt)) return new DocumentCstmrCdtTrfInitnPmtInfDbtrAgtSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnId)) return new DocumentCstmrCdtTrfInitnPmtInfDbtrAgtFinInstnIdSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInf)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtId)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtIdSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInf)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvl)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfPmtTpInfSvcLvlSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmt)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmt)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfAmtInstdAmtSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtr)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrID)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtId)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthr)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrIDPrvtIdOthrSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcct)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctID)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfCdtrAcctIDSerializer();
            if (type == typeof(global::DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInf)) return new DocumentCstmrCdtTrfInitnPmtInfCdtTrfTxInfRmtInfSerializer();
            return null;
        }
    }
}

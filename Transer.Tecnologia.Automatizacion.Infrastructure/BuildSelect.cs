using System.Text;
namespace Transer.Tecnologia.Automatizacion.Infrastructure
{
    class BuildSelect
    {
        public string GetCommand(string s)
        {
            string select = string.Empty;
            switch (s)
            {
                case "InformacionDian21":
                    {
                        select = InformacionDian21();
                        break;
                    }
                case "getLogReporteDian":
                    {
                        select = getLogReporteDian();
                        break;
                    }
                case "getInformacionDian":
                    {
                        select = getInformacionDian();
                        break;
                    }
                case "getInformacionCorreoClientes":
                    {
                        select = getInformacionCorreoClientes();
                        break;
                    }//getInformacionCorreoClientes
                case "pdbInfoDianFactura":
                    {
                        select = pdbInfoDianFactura();
                        break;
                    }
                case "pdbInfoDianNota":
                    {
                        select = pdbInfoDianNota();
                        break;
                    }
                case "pdbInfoDianNotaOperativo":
                    {
                        select = pdbInfoDianNotaOperativo();
                        break;
                    }
                case "FDB_LEER_ANEXOS_DIAN":
                    {
                        select = FDB_LEER_ANEXOS_DIAN();
                        break;
                    }
                case "getCliente":
                    {
                        select = getCliente();
                        break;
                    }
                case "UploadRequestFE":
                    {
                        select = UploadRequestFE();
                        break;
                    }
                case "insertDetLogDian":
                    {
                        select = insertDetLogDian();
                        break;
                    }
                case "updateLogReporteDian":
                    {
                        select = updateLogReporteDian();
                        break;
                    }
                case "updateInformacionDian":
                    {
                        select = updateInformacionDian();
                        break;
                    }
                case "updateInfoDianCufe":
                    {
                        select = updateInfoDianCufe();
                        break;
                    }
                case "updateDetLogDianCufe":
                    {
                        select = updateDetLogDianCufe();
                        break;
                    }
                case "updateLogReporteDianCufe":
                    {
                        select = updateLogReporteDianCufe();
                        break;
                    }
                case "updateInfoDianFactura":
                    {
                        select = updateInfoDianFactura();
                        break;
                    }
                case "getInformacionDianEnProceso":
                    {
                        select = getInformacionDianEnProceso();
                        break;
                    }
                case "getLogReporteBavaria":
                    {
                        select = getLogReporteBavaria();
                        break;
                    }
                case "getInfoBavaria":
                    {
                        select = getInfoBavaria();
                        break;
                    }
                case "InsertDetLogBavaria":
                    {
                        select = InsertDetLogBavaria();
                        break;
                    }
                case "UpdateLogReporteBavaria":
                    {
                        select = UpdateLogReporteBavaria();
                        break;
                    }
                case "pdbInfoDianFacturaOperativo":
                    {
                        select = pdbInfoDianFacturaOperativo();
                        break;
                    }
                case "getLogReporteMinisterio":
                    {
                        select = getLogReporteMinisterio();
                        break;
                    }
                case "getLogReporteMinisterioEnvioUnitario":
                    {
                        select = getLogReporteMinisterioEnvioUnitario();
                        break;
                    }

                case "getLogReporteMinisterioEstadoTransaccion":
                    {
                        select = getLogReporteMinisterioEstadoTransaccion();
                        break;
                    }
                case "PK_MINISTERIO_XML_REMESA":
                    {
                        select = PK_MINISTERIO_XML_REMESA();
                        break;
                    }
                case "PK_MINISTERIO_XML_MANIFIESTO_CARGA":
                    {
                        select = PK_MINISTERIO_XML_MANIFIESTO_CARGA();
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIDO_REMESA":
                    {
                        select = PK_MINISTERIO_XML_CUMPLIDO_REMESA();
                        break;
                    }
                case "PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO":
                    {
                        select = PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO();
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_NIT":
                    {
                        select = PK_MINISTERIO_XML_PROPIETARIOS_NIT();
                        break;
                    }
                case "PK_MINISTERIO_XML_PROPIETARIOS_CEDULA":
                    {
                        select = PK_MINISTERIO_XML_PROPIETARIOS_CEDULA();
                        break;
                    }
                case "PK_MINISTERIO_XML_CONDUCTORES":
                    {
                        select = PK_MINISTERIO_XML_CONDUCTORES();
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_NIT":
                    {
                        select = PK_MINISTERIO_XML_CLIENTES_NIT();
                        break;
                    }
                case "PK_MINISTERIO_XML_CLIENTES_CEDULA":
                    {
                        select = PK_MINISTERIO_XML_CLIENTES_CEDULA();
                        break;
                    }
                case "PK_MINISTERIO_XML_VEHICULOS":
                    {
                        select = PK_MINISTERIO_XML_VEHICULOS();
                        break;
                    }
                case "PK_MINISTERIO_XML_TRAILERS":
                    {
                        select = PK_MINISTERIO_XML_TRAILERS();
                        break;
                    }
                case "PK_MINISTERIO_XML_ANULAR_MANIFIESTO":
                    {
                        select = PK_MINISTERIO_XML_ANULAR_MANIFIESTO();
                        break;
                    }
                case "PK_MINISTERIO_XML_ANULAR_REMESA":
                    {
                        select = PK_MINISTERIO_XML_ANULAR_REMESA();
                        break;
                    }
                case "InsertDetLogMinisterio":
                    {
                        select = InsertDetLogMinisterio();
                        break;
                    }
                case "getDetLogMinisterio":
                    {
                        select = getDetLogMinisterio();
                        break;
                    }
                case "UpdateLogReporteMinisterio":
                    {
                        select = UpdateLogReporteMinisterio();
                        break;
                    }
                case "UpdateLogReporteMinisterioCampo1":
                    {
                        select = UpdateLogReporteMinisterioCampo1();
                        break;
                    }
                case "getInfoLogReporteBavaria":
                    {
                        select = getInfoLogReporteBavaria();
                        break;
                    }
                case "getDetalleDetLogBavaria":
                    {
                        select = getDetalleDetLogBavaria();
                        break;
                    }
                case "getUrbanos":
                    {
                        select = getUrbanos();
                        break;
                    }
                case "getUpdateUrbanos":
                    {
                        select = getUpdateUrbanos();
                        break;
                    }
                case "getLogReporteMinisterioTransaccionLlave":
                    {
                        select = getLogReporteMinisterioTransaccionLlave();
                        break;
                    }
                default:
                    break;
            }
            return select;
        }
        private string InformacionDian21()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select INDI_NUMDOC_V2, ");
            select.Append(" INDI_OFICDOC_NB, ");
            select.Append(" INDI_TIPODOC_V2, ");
            select.Append(" INDI_EMAIL_V2, ");
            select.Append(" INDI_XMLENV_CB, ");
            select.Append(" INDI_CUFEDIAN_V2, ");
            select.Append(" INDI_IDCARVAJAL_V2, ");
            select.Append(" INDI_XMLREC_BL, ");
            select.Append(" INDI_REPGRAFICA_BL, ");
            select.Append(" INDI_XMLLEGAL_CB, ");
            select.Append(" INDI_IDCUFE_V2, ");
            select.Append(" INDI_FECCREA_TS, ");
            select.Append(" INDI_FECESTADO_TS, ");
            select.Append(" INDI_VALIDACION_CL, ");
            select.Append(" INDI_CLIENTE_NB, ");
            select.Append(" INDI_NOMCLIENTE_V2 ");
            select.Append(" from informacion_dian_21 ");
            select.Append(" where INDI_NUMDOC_V2 =:numdoc ");
            select.Append(" and INDI_TIPODOC_V2 =:tipodoc ");
            select.Append(" order by 1; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getLogReporteDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LODI_SECUENCIA_NB, ");
            select.Append(" LODI_OFICINA_NB, ");
            select.Append(" LODI_TRANSACCION_NB, ");
            select.Append(" LODI_LLAVE_V2, ");
            select.Append(" LODI_FECREGISTRO_DT, ");
            select.Append(" LODI_ESTADO_V2, ");
            select.Append(" LODI_CAMPO1_NB, ");
            select.Append(" LODI_CAMPO2_V2, ");
            select.Append(" LODI_CAMPO3_DT, ");
            select.Append(" LODI_ESTADODIAN_V2 ");
            select.Append(" from log_reporte_dian ");
            select.Append(" where LODI_ESTADO_V2 =:LODI_ESTADO ");
            select.Append(" and LODI_TRANSACCION_NB IN (1,2) ");
            select.Append(" order by LODI_FECREGISTRO_DT; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getInformacionDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select INDI_NUMDOC_V2, ");
            select.Append(" INDI_OFICDOC_NB, ");
            select.Append(" INDI_TIPODOC_V2, ");
            select.Append(" INDI_EMAIL_V2, ");
            select.Append(" INDI_XMLENV_CB, ");
            select.Append(" INDI_CUFEDIAN_V2, ");
            select.Append(" INDI_IDCARVAJAL_V2, ");
            select.Append(" INDI_XMLREC_BL, ");
            select.Append(" INDI_REPGRAFICA_BL, ");
            select.Append(" INDI_XMLLEGAL_CB, ");
            //select.Append(" INDI_IDCUFE_V2, ");
            select.Append(" INDI_FECCREA_TS, ");
            select.Append(" INDI_FECESTADO_TS, ");
            select.Append(" INDI_VALIDACION_CL, ");
            //select.Append(" INDI_CLIENTE_NB ");
            select.Append(" INDI_CLIENTE_NB, ");
            select.Append(" INDI_NOMCLIENTE_V2 ");
            select.Append(" from informacion_dian ");
            select.Append(" where INDI_NUMDOC_V2 =:INDI_NUMDOC ");
            select.Append(" order by 1; ");
            select.Append("end;");
            return select.ToString();
        }
        
        private string getInformacionCorreoClientes()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select COCF_SECUENCIA_NB, ");
            select.Append(" COCF_CLIENTE_NB, ");
            select.Append(" COCF_EMAIL_V2, ");
            select.Append(" COCF_ESTADO_V2, ");
            select.Append(" COCF_FECCREA_DT, ");
            select.Append(" COCF_USUCREA_NB, ");
            select.Append(" COCF_USUANULA_NB, ");
            select.Append(" COCF_FECANULA_DT ");
            select.Append(" from correos_copiafactura ");
            select.Append(" where COCF_CLIENTE_NB =:COCF_CLIENTE ");
            select.Append(" and COCF_ESTADO_V2 = 'A' ");
            select.Append(" order by 1; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getInformacionDianEnProceso()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select INDI_NUMDOC_V2, ");
            select.Append(" INDI_OFICDOC_NB, ");
            select.Append(" INDI_TIPODOC_V2, ");
            select.Append(" INDI_EMAIL_V2, ");
            select.Append(" INDI_XMLENV_CB, ");
            select.Append(" INDI_CUFEDIAN_V2, ");
            select.Append(" INDI_IDCARVAJAL_V2, ");
            select.Append(" INDI_XMLREC_BL, ");
            select.Append(" INDI_REPGRAFICA_BL, ");
            select.Append(" INDI_XMLLEGAL_CB, ");
            //select.Append(" INDI_IDCUFE_V2, ");
            select.Append(" INDI_FECCREA_TS, ");
            select.Append(" INDI_FECESTADO_TS, ");
            select.Append(" INDI_VALIDACION_CL, ");
            //select.Append(" INDI_CLIENTE_NB ");            
            select.Append(" INDI_CLIENTE_NB, ");
            select.Append(" INDI_NOMCLIENTE_V2 ");

            //select.Append(" from informacion_dian ");
            select.Append(" from informacion_dian_21 ");
            select.Append(" where INDI_CUFEDIAN_V2 ='EN PROCESO' ");
            select.Append(" order by 1; ");
            select.Append("end;");
            return select.ToString();
        }
        private string pdbInfoDianFactura()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" var varchar2(4000); ");
            select.Append(" begin ");
            //select.Append(" pdb_info_fc_dian(:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            //select.Append(" PDB_INFO_FC_DIAN_21 (:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" PDB_INFO_FC_DIAN_21_R18 (:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" end; ");
            return select.ToString();
        }
        private string pdbInfoDianNota()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" var varchar2(4000); ");
            select.Append(" begin ");
            //select.Append(" pdb_info_nc_dian(:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" PDB_INFO_NC_DIAN_21 (:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" end; ");
            return select.ToString();
        }
        private string pdbInfoDianFacturaOperativo()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" var varchar2(4000); ");
            select.Append(" begin ");
            //select.Append(" pdb_info_fc_dian(:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            //select.Append(" PDB_INFO_FM_DIAN_21 (:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" PDB_INFO_FM_DIAN_21_R18 (:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" end; ");
            return select.ToString();
        }
        private string pdbInfoDianNotaOperativo()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" var varchar2(4000); ");
            select.Append(" begin ");
            //select.Append(" pdb_info_nc_dian(:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" PDB_INFO_NCT_DIAN_21 (:factura,:oficina,:tipodoc,:tipotransaccion,var); ");
            select.Append(" end; ");
            return select.ToString();
        }
        private string FDB_LEER_ANEXOS_DIAN()
        {
            StringBuilder select = new StringBuilder();
            select.Append("FDB_LEER_ANEXOS_DIAN");
            /*select.Append(" declare ");
            select.Append(" refcur1 SYS_REFCURSOR;  ");
            select.Append(" begin ");
            select.Append(" refcur1:=FDB_LEER_ANEXOS_DIAN (p_numdoc_v,p_oficina_n,p_tipodoc_v); ");
            select.Append(" end; ");*/
            return select.ToString();
        }
        private string getCliente()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select CLIE_NOMBRE_V2 cliente ");
            select.Append(" from facturas,clientes ");
            select.Append(" where FACT_CLIEPAGA_NB=CLIE_CODIGO_NB ");
            select.Append(" and FACT_NOFACTURA_NB=:factura;");
            select.Append("end;");
            return select.ToString();
        }
        private string UploadRequestFE()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append("  begin ");
            select.Append("  declare ");
            select.Append(" begin ");
            select.Append(" insert into upload (uplo_secuencia_nb,uplo_fechaenvio_ts,uplo_filename_v2,uplo_filedata_bl,uplo_companyid_v2, uplo_accountid_v2, uplo_status_v2, uplo_transactionid_v2, uplo_xmlfactura_bl, uplo_soapenviado_bl, uplo_soaprespuesta_bl) ");
            select.Append(" values (upload_sequence.nextval,sysdate,:filename,:filedata,:companyid,:accountid,:status,:transactionid,:xmlfactura,:soapenviado,:soaprespuesta);end;");
            select.Append(" end;");
            return select.ToString();
        }
        private string insertDetLogDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append("  declare  ");
            select.Append("  begin  ");
            select.Append("  insert into det_log_dian (DELD_SECUENCIA_NB,  ");
            select.Append("  DELD_LOGSECUENCIA_NB,  ");
            select.Append("  DELD_OFICINA_NB,  ");
            select.Append("  DELD_TRANSACCION_NB,  ");
            select.Append("  DELD_LLAVE_V2,  ");
            select.Append("  DELD_ESTADO_V2,  ");
            select.Append("  DELD_IDDIAN_V2,  ");
            select.Append("  DELD_CUFEDIAN_V2,  ");
            select.Append("  DELD_SOAPENVIADO_BL,  ");
            select.Append("  DELD_FECHAENVIO_DT,  ");
            select.Append("  DELD_SOAPRECIBIDO_BL,  ");
            select.Append("  DELD_CAMPO1_NB,  ");
            select.Append("  DELD_CAMPO2_V2,  ");
            select.Append("  DELD_CAMPO3_DT)  ");
            select.Append("  values ((select count(deld_secuencia_nb)+1 from det_log_dian where DELD_LOGSECUENCIA_NB=:secuencia),:secuencia,:oficina,:transacion,:llave,:estado,:iddian,:cufe,:soapEnviado,sysdate,:soapRecibido,null,null,null);  ");
            select.Append("  end;  ");
            return select.ToString();
        }
        private string updateLogReporteDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_dian set ");
            select.Append(" lodi_estado_v2=:estado ");
            select.Append(" where lodi_llave_v2=:factura;");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string updateInformacionDian()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update informacion_dian set ");
            select.Append(" INDI_IDCARVAJAL_V2=:INDI_IDCARVAJAL,");
            select.Append(" INDI_CUFEDIAN_V2=:INDI_CUFEDIAN");
            select.Append(" where INDI_NUMDOC_V2=:INDI_NUMDOC;");
            select.Append(" end; ");
            return select.ToString();
        }
        private string updateInfoDianCufe()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update informacion_dian set ");
            select.Append(" indi_cufedian_v2=:INDI_CUFEDIAN, ");
            //select.Append(" indi_xmllegal_cb=:indi_xmllegal ");
            select.Append(" indi_xmlrec_bl=:indi_xmlrec ");
            select.Append(" where indi_numdoc_v2=:INDI_NUMDOC;");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string updateDetLogDianCufe()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update det_log_dian set ");
            select.Append(" DELD_CUFEDIAN_V2=:DELD_CUFEDIAN, ");
            select.Append(" DELD_ESTADO_V2='E'");
            select.Append(" where DELD_LLAVE_V2=:DELD_LLAVE;");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string updateLogReporteDianCufe()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_dian set ");
            select.Append(" LODI_ESTADO_V2='E', ");
            select.Append(" LODI_ESTADODIAN_V2='E', ");
            select.Append(" LODI_CAMPO3_DT=sysdate ");
            select.Append(" where LODI_LLAVE_V2=:LODI_LLAVE;");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string updateInfoDianFactura()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update informacion_dian set ");
            select.Append(" indi_repgrafica_bl=:indi_repgrafica ");
            select.Append(" where indi_numdoc_v2=:INDI_NUMDOC;");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string getLogReporteBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select REBA_SECUENCIA_NB, ");
            select.Append(" REBA_OFICINA_NB, ");
            select.Append(" REBA_TRANSACCION_NB, ");
            select.Append(" REBA_LLAVE_V2, ");
            select.Append(" REBA_FECHA_DT, ");
            select.Append(" REBA_ESTADO_V2 ");
            select.Append(" from LOG_REPORTE_BAVARIA ");
            select.Append(" where REBA_SECUENCIA_NB > 67414 ");
            select.Append(" and REBA_ESTADO_V2='P' ");
            //select.Append(" and trunc(REBA_FECHA_DT) between trunc(sysdate-341) and trunc(sysdate-59) ");
            //select.Append(" and trunc(REBA_FECHA_DT) between trunc(sysdate-341) and trunc(sysdate-300) ");
            select.Append(" order by REBA_SECUENCIA_NB; ");
            //select.Append(" and REBA_ESTADO_V2 = :REBA_ESTADO; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getLogReporteBavariaTMP()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select REBA_SECUENCIA_NB, ");
            select.Append(" REBA_OFICINA_NB, ");
            select.Append(" REBA_TRANSACCION_NB, ");
            select.Append(" REBA_LLAVE_V2, ");
            select.Append(" REBA_FECHA_DT, ");
            select.Append(" REBA_ESTADO_V2 ");
            select.Append(" from LOG_REPORTE_BAVARIA ");
            select.Append(" where REBA_ESTADO_V2 = :REBA_ESTADO; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getInfoBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" SELECT V.VIAJ_NOPLANILLA_V2, ");
            select.Append(" O.OFIC_NOMBRE_V2, ");
            select.Append(" V.VIAJ_PLACA_CH, ");
            select.Append(" CV.CLVE_DESCRIP_V2, ");
            select.Append(" V.VIAJ_TRAILER_CH, ");
            select.Append(" V.VIAJ_FECVIAJE_DT, ");
            select.Append(" CM.CAMI_KMSTOTAL_NB, ");
            select.Append(" C.COND_NOMBRE_V2 || ' ' || C.COND_APELLIDO_V2 CONDUCTOR, ");
            select.Append(" C.COND_CEDULA_NB, ");
            select.Append(" CO.CIUD_DESCRIPCION_V2 CIUD_ORIGEN, ");
            select.Append(" CO.CIUD_CODIGO_NB COD_ORIGEN, ");
            select.Append(" CD.CIUD_DESCRIPCION_V2 CIUD_DESTINO, ");
            select.Append(" CD.CIUD_CODIGO_NB COD_DESTINO, ");
            select.Append(" CO.CIUD_DESCRIPCION_V2 || '-' || CD.CIUD_DESCRIPCION_V2 ORIGEN_DESTINO, ");
            select.Append(" O.ORCA_RUTA_NB, ");
            select.Append(" P.PROD_NOMBRE_V2, ");
            select.Append(" EMPAQ.GENE_DESCRIPCION_V2 ");
            select.Append(" FROM VIAJES V, OFICINAS O, CONDUCTORES C, ORDENES_CARGUE O, RUTAS R, ");
            select.Append(" CIUDADES CO, CIUDADES CD, VIAJE_DESTINOS VD, CUMPLIDOS M, ");
            select.Append(" PRODUCTOS P, VEHICULOS H, CLASE_VEHICULO CV, CAMINOS CM, GENERICAS EMPAQ ");
            select.Append(" WHERE V.VIAJ_OFDESPACHA_NB = O.OFIC_CODOFIC_NB ");
            select.Append(" AND V.VIAJ_CONDUCTOR_NB = C.COND_CEDULA_NB ");
            select.Append(" AND V.VIAJ_ORDCARGUE_NB = O.ORCA_NUMERO_NB ");
            select.Append(" AND CO.CIUD_CODIGO_NB = R.RUTA_ORIGEN_NB ");
            select.Append(" AND CD.CIUD_CODIGO_NB = R.RUTA_DESTINO_NB ");
            select.Append(" AND V.VIAJ_NOPLANILLA_V2 = M.CUMP_PLANILLA_V2 ");
            select.Append(" AND M.CUMP_NEGOCIO_NB = VD.VIDE_NEGOCIO_NB ");
            select.Append(" AND M.CUMP_NEGRUTSEC_NB = VD.VIDE_NEGRUTSEC_NB ");
            select.Append(" AND M.CUMP_PLANILLA_V2 = VD.VIDE_PLANILLA_V2 ");
            select.Append(" AND M.CUMP_NERUCAMINO_NB = VD.VIDE_NERUCAMINO_NB ");
            select.Append(" AND M.CUMP_NERURUTA_NB = VD.VIDE_NERURUTA_NB ");
            select.Append(" AND M.CUMP_PRODUCTO_NB = P.PROD_CODIGO_NB ");
            select.Append(" AND V.VIAJ_PLACA_CH = H.VEHI_PLACA_CH ");
            select.Append(" AND H.VEHI_CLASE_NB = CV.CLVE_SECUENCIA_NB ");
            select.Append(" AND VD.VIDE_NERURUTA_NB = R.RUTA_CODIGO_NB ");
            select.Append(" AND VD.VIDE_NERURUTA_NB = CM.CAMI_RUTA_NB ");
            select.Append(" AND VD.VIDE_NERUCAMINO_NB = CM.CAMI_SECUENCIA_NB ");
            select.Append(" AND M.CUMP_TIPOEMPAQUE_NB = EMPAQ.GENE_CODIGO_NB ");
            select.Append(" AND EMPAQ.GENE_NOMBRE_V2 = 'TIPOEMPAQUE' ");
            select.Append(" AND VD.VIDE_ESTADO_V2 != 'L' ");
            select.Append(" AND M.CUMP_ESTADO_V2 != 'L' ");
            select.Append(" AND V.VIAJ_NOPLANILLA_V2 =:VIAJ_NOPLANILLA; ");
            select.Append("end;");
            return select.ToString();
        }
        private string InsertDetLogBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" insert into det_log_bavaria(DEBA_SECUENCIA_NB,DEBA_LOGBAVARIA_NB,DEBA_OFICINA_NB,DEBA_TRANSACCION_NB,DEBA_LLAVE_V2,DEBA_NUMACEPTA_NB,DEBA_ESTADO_V2,DEBA_SOAPENVIADO_V2,DEBA_SOAPRECIBIDO_V2,DEBA_FECPROCESA_DT,DEBA_CAMPO1_NB,DEBA_CAMPO2_DT,DEBA_CAMPO3_V2) ");
            select.Append(" values ((select count(DEBA_SECUENCIA_NB)+1 from det_log_bavaria where DEBA_LOGBAVARIA_NB=:logbavaria and DEBA_OFICINA_NB=:oficina),:logbavaria,:oficina,4,:llave,:numacepta,:estado,:Bavariasoapenviado,:Bavariasoaprecibido,sysdate,null,null,null); ");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string UpdateLogReporteBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_bavaria set ");
            select.Append(" REBA_ESTADO_V2=:REBA_ESTADO_V2 ");
            select.Append(" where REBA_SECUENCIA_NB=:REBA_SECUENCIA_NB ");
            select.Append(" and REBA_OFICINA_NB=:REBA_OFICINA_NB; ");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string getLogReporteMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB,  ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" LRMI_CAMPO1_NB, ");
            select.Append(" LRMI_CAMPO2_V2, ");
            select.Append(" LRMI_CAMPO3_DT  ");
            select.Append(" from log_reporte_ministerio  ");
            select.Append(" where LRMI_ESTADO_V2 =:LRMI_ESTADO  ");
            //select.Append(" and LRMI_SECUENCIA_NB<3062409  ");
            //select.Append(" and LRMI_SECUENCIA_NB<3062409  ");
            select.Append(" order by LRMI_FECREGISTRO_DT;  ");
            select.Append("end;");
            return select.ToString();
        }

        private string getLogReporteMinisterioEstadoTransaccion()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB,  ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" LRMI_CAMPO1_NB, ");
            select.Append(" LRMI_CAMPO2_V2, ");
            select.Append(" LRMI_CAMPO3_DT  ");
            select.Append(" from log_reporte_ministerio  ");
            select.Append(" where LRMI_ESTADO_V2 =:LRMI_ESTADO  ");
            select.Append(" and LRMI_TRANSACCION_NB =:LRMI_TRANSACCION  ");
            select.Append(" and trunc(LRMI_FECREGISTRO_DT) between trunc(sysdate-720) and trunc(sysdate)  ");
            select.Append(" order by LRMI_FECREGISTRO_DT;  ");
            select.Append("end;");
            return select.ToString();
        }

        private string getLogReporteMinisterioEnvioUnitario()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB,  ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" LRMI_CAMPO1_NB, ");
            select.Append(" LRMI_CAMPO2_V2, ");
            select.Append(" LRMI_CAMPO3_DT  ");
            select.Append(" from log_reporte_ministerio  ");
            select.Append(" where LRMI_LLAVE_V2 =:LRMI_LLAVE  ");
            select.Append(" AND LRMI_TRANSACCION_NB =:LRMI_TRANSACCION  ");
            select.Append(" order by LRMI_FECREGISTRO_DT;  ");
            select.Append("end;");
            return select.ToString();
        }

        private string PK_MINISTERIO_XML_REMESA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT DISTINCT '8605048823' numNitEmpresaTransporte,  ");
            select.Append(" ORCA_NUMERO_NB consecutivoRemesa,  ");
            select.Append(" '' consecutivoInformacionCarga,  ");
            select.Append(" 'G' codOperacionTransporte,  ");
            select.Append(" '1' codNaturalezaCarga,  ");
            select.Append(" ORCA_PESOKGS_NB cantidadCargada,  ");
            select.Append(" DECODE(ORCA_VOLUMEN_NB,'K',1,'V',1,ORCA_VOLUMEN_NB) unidadMedidaCapacidad,  ");
            select.Append(" DECODE(ORCA_TIPOEMPAQUE_NB,3,6,2,4,11,12,14,15,12,17,10,19,1,19,0) codTipoEmpaque,  ");
            select.Append(" '' pesoContenedorVacio,  ");
            select.Append(" PROD_MIN_V2 mercanciaRemesa,  ");
            select.Append(" SUBSTR(PROD_NOMBRE_V2 ,1,60) descripcionCortaProducto,  ");
            select.Append(" decode(CLIENTES_A.CLIE_TIPOIDENT,null,'N',CLIENTES_A.CLIE_TIPOIDENT) codTipoIdRemitente,  ");
            select.Append(" CLIENTES_A.CLIE_NIT_NB||decode(length(CLIENTES_A.CLIE_NIT_NB),10,null,9,f_chequeonit(CLIENTES_A.CLIE_NIT_NB,1),null) numIdRemitente,  ");
            select.Append(" PLANTAS.PLAN_CODIGO_NB codSedeRemitente,  ");
            select.Append(" decode(CLIENTES_B.CLIE_TIPOIDENT,null,'N',CLIENTES_B.CLIE_TIPOIDENT) codTipoIdDestinatario,  ");
            select.Append(" CLIENTES_B.CLIE_NIT_NB||decode(length(CLIENTES_B.CLIE_NIT_NB),10,null,9,f_chequeonit(CLIENTES_B.CLIE_NIT_NB,1),null) numIdDestinatario,  ");
            select.Append(" PLANTAS_A1.PLAN_CODIGO_NB codSedeDestinatario,  ");
            select.Append(" 'E' duenoPoliza,  ");
            select.Append(" 1000007 numPolizaTransporte,  ");
            select.Append(" 8600024002 companiaSeguro,  ");
            select.Append(" '31/03/2014' fechaVencimientoPolizaCarga,  ");
            select.Append("  11 HORASPACTOCARGA,  ");
            select.Append("  59 MINUTOSPACTOCARGA,  ");
            select.Append("  11 horasPactoDescargue,  ");
            select.Append("  59 minutosPactoDescargue,  ");
            select.Append("  to_char(ORCA_FECCREA_DT + (1/24),'dd/mm/yyyy') fechaLlegadaCargue,  ");
            select.Append("  to_char(ORCA_FECCREA_DT + (1/24), 'HH24:MI') horaLlegadaCargueRemesa,  ");
            select.Append("  to_char(ORCA_FECCREA_DT + (2/24),'dd/mm/yyyy') fechaEntradaCargue,  ");
            select.Append("  to_char(ORCA_FECCREA_DT + (2/24), 'HH24:MI') horaEntradaCargueRemesa,  ");
            select.Append(" to_char(ORCA_FECCREA_DT + (4/24),'dd/mm/yyyy') fechaSalidaCargue,  ");
            select.Append(" to_char(ORCA_FECCREA_DT + (4/24), 'HH24:MI') horaSalidaCargueRemesa,  ");
            select.Append(" decode(clientes_a.CLIE_TIPOIDENT,null,'N',clientes_a.CLIE_TIPOIDENT) codTipoIdPropietario,  ");
            select.Append(" CLIENTES_A.CLIE_NIT_NB||decode(length(CLIENTES_A.CLIE_NIT_NB),10,null,9,f_chequeonit(CLIENTES_A.CLIE_NIT_NB,1),null) numIdPropietario,  ");
            select.Append(" PLANTAS.PLAN_CODIGO_NB codSedePropietario,  ");
            select.Append(" to_char(ORCA_FECCREA_DT + (1/24),'dd/mm/yyyy') fechaCitaPactadaCargue,  ");
            select.Append(" to_char(ORCA_FECCREA_DT + (1/24), 'HH24:MI') horaCitaPactadaCargue,  ");
            select.Append(" to_char(ORCA_FECCREA_DT +1,'dd/mm/yyyy') fechaCitaPactadaDescargue,  ");
            select.Append(" to_char(ORCA_FECCREA_DT + (2/24), 'HH24:MI') horaCitaPactadaDescargueRemesa  ");
            select.Append(" FROM ORDENES_CARGUE,CLIENTES CLIENTES,NEGOCIOS_PRODUCTOS, PRODUCTOS,CLIENTES_PLANTAS,PLANTAS,  ");
            select.Append(" PLANTAS PLANTAS_A1, CLIENTES_PLANTAS CLIENTES_PLANTAS_A1,CLIENTES CLIENTES_A,  ");
            select.Append(" CLIENTES CLIENTES_B/*,CLIENTES CLIENTES_A1*/  ");
            select.Append(" WHERE ORCA_CLIENTEPAGA_NB=CLIENTES.CLIE_CODIGO_NB  ");
            select.Append(" AND ORCA_NITREM_NB=CLIENTES_A.CLIE_CODIGO_NB  ");
            select.Append(" AND ORCA_CLIENTEREC_NB=CLIENTES_B.CLIE_CODIGO_NB  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NEGOCIO_NB=NEGOCIOS_PRODUCTOS.NEPR_NRONEGOCIO_NB  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PRODUCTO_NB=NEGOCIOS_PRODUCTOS.NEPR_PRODUCTO_NB  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PRODUCTO_NB=PRODUCTOS.PROD_CODIGO_NB  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PLANTAREMITE_NB=CLIENTES_PLANTAS.CIPA_PLANTA_NB(+)  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PLANTAREMITE_NB=PLANTAS.PLAN_CODIGO_NB(+)  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PLANTARECIBE_NB=CLIENTES_PLANTAS_A1.CIPA_PLANTA_NB(+)  ");
            select.Append(" AND ORDENES_CARGUE.ORCA_PLANTARECIBE_NB=PLANTAS_A1.PLAN_CODIGO_NB(+)  ");
            select.Append(" and ORCA_NUMERO_NB=:llave; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_MANIFIESTO_CARGA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT DISTINCT '8605048823' numNitEmpresaTransporte, ");
            select.Append(" VIAJES.VIAJ_NOPLANILLA_V2 numManifiestoCarga, ");
            select.Append(" ORDENES_CARGUE.ORCA_NUMERO_NB consecutivoRemesa, ");
            select.Append(" 'G' codOperacionTransporte, ");
            select.Append(" to_char(VIAJ_FECVIAJE_DT,'dd/mm/yyyy') fechaExpedicionManifiesto, ");
            select.Append(" CIUDADES.CIUD_DIVIPOLA_CH codMunicipioOrigenManifiesto, ");
            select.Append(" CIUDADES_A1.CIUD_DIVIPOLA_CH codMunicipioDestinoManifiesto, ");
            select.Append(" PROPIETARIOS.PROP_TIPOIDEN_V2 codIdTitularManifiesto, ");
            select.Append(" PROPIETARIOS.PROP_CEDULA_NB||decode(length(PROP_CEDULA_NB),10,null,9,f_chequeonit(PROP_CEDULA_NB,1),null) numIdTitularManifiesto, ");
            select.Append(" VIAJ_PLACA_CH numPlaca, ");
            select.Append(" ORDENES_CARGUE.ORCA_TRAILER_CH numPlacaRemolque, ");
            select.Append(" CONDUCTORES.COND_TIPOIDEN_V2 codIdConductor, ");
            select.Append(" CONDUCTORES.COND_CEDULA_NB numIdconductor, ");
            select.Append(" decode(Viaj_ClaseVehi_Nb,0,0,fdb_flete_cond(viajes.viaj_noplanilla_v2)) valorFletePactadoViaje, ");
            select.Append(" decode(Viaj_ClaseVehi_Nb,0,0,1) retencionFuenteManifiesto, ");
            select.Append(" decode(fdb_flete_cond(viajes.viaj_noplanilla_v2),0,0,decode(Viaj_ClaseVehi_Nb,0,0,round(nvl(FDB_CALRTEICA(viaj_ofdespacha_nb,viaj_noplanilla_v2),0)*1000/fdb_flete_cond(viajes.viaj_noplanilla_v2),3))) retencionIcaManifiestoCarga, ");
            select.Append(" decode(Viaj_ClaseVehi_Nb,0,0,FDB_ANTICIPOS_VIAJE(VIAJ_NOPLANILLA_V2)) ValorAnticipoManifiesto, ");
            select.Append(" CIUDADES.CIUD_DIVIPOLA_CH codMunicipioPagoSaldo, ");
            select.Append(" 'R' codResponsablePagoCargue,'D' codResponsablePagoDescargue,substr(VIAJ_OBSERVACIONES_V2,1,200)  observaciones, ");
            select.Append(" to_char(VIAJ_FECVIAJE_DT+10,'dd/mm/yyyy')  fechaPagoSaldoManifiesto, ");
            select.Append(" ORDENES_CARGUE.ORCA_NUMERO_NB  consecutivoRemesa ");
            select.Append(" FROM ORDENES_CARGUE, VIAJES, CIUDADES, ");
            select.Append(" CIUDADES CIUDADES_A1, RUTAS, PROPIETARIOS, ");
            select.Append(" CONDUCTORES, VIAJES_ANTICIPOS ");
            select.Append(" where ((ORDENES_CARGUE.ORCA_NUMERO_NB=VIAJES.VIAJ_ORDCARGUE_NB) ");
            select.Append(" AND (ORDENES_CARGUE.ORCA_RUTA_NB=RUTAS.RUTA_CODIGO_NB) ");
            select.Append(" AND (RUTAS.RUTA_ORIGEN_NB=CIUDADES.CIUD_CODIGO_NB) ");
            select.Append(" AND (RUTAS.RUTA_DESTINO_NB=CIUDADES_A1.CIUD_CODIGO_NB) ");
            select.Append(" AND (VIAJES.VIAJ_POSEEDOR_NB=PROPIETARIOS.PROP_CEDULA_NB) ");
            select.Append(" AND (VIAJES.VIAJ_CONDUCTOR_NB=CONDUCTORES.COND_CEDULA_NB) ");
            select.Append(" AND (VIAJES.VIAJ_NOPLANILLA_V2=VIAJES_ANTICIPOS.VIAN_PLANILLA_V2(+))) ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2=:llave; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_CUMPLIR_MANIFIESTO()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' numNitEmpresaTransporte, ");
            select.Append(" LIQU_PLANILLA_V2 numManifiestoCarga, ");
            select.Append(" 'C' tipoCumplidoManifiesto, ");
            select.Append(" '' motivoSuspensionManifiesto, ");
            select.Append(" to_char(LIQU_FECHA_DT,'DD/MM/YYYY') fechaEntregaDocumentos, ");
            select.Append(" '' consecuenciaSuspension, ");
            select.Append(" 0 valorAdicionalHorasCargue, ");
            select.Append(" 0 valorAdicionalHorasDescargue, ");
            select.Append(" 0 valorAdicionalFlete, ");
            select.Append(" '' motivoValorAdicional, ");
            select.Append(" 0 valorDescuentoFlete, ");
            select.Append(" 0 motivoValorDescuentoManifiesto, ");
            select.Append(" 0 valorSobreanticipo, ");
            select.Append(" substr(LIQU_OBSERVACIONES_V2,1,200) observaciones ");
            select.Append(" FROM liquidaciones ");
            select.Append(" where LIQU_PLANILLA_V2=:llave ");
            select.Append(" and LIQU_ESTADO_V2='A'; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_CUMPLIDO_REMESA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");
            select.Append(" SELECT DISTINCT 8605048823 numNitEmpresaTransporte,   ");
            select.Append(" ORDENES_CARGUE.ORCA_NUMERO_NB consecutivoRemesa,   ");
            select.Append(" VIAJES.VIAJ_NOPLANILLA_V2 numManifiestoCarga,   ");
            select.Append(" 'C' tipoCumplidoRemesa,   ");
            select.Append(" '' motivoSuspensionRemesa,   ");
            select.Append(" FDB_KDESPACHADOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadCargada,   ");
            select.Append(" FDB_KRECIBIDOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadEntregada,   ");
            select.Append(" DECODE(ORCA_VOLUMEN_NB, 'K', 1, 'V', 1, ORCA_VOLUMEN_NB) unidadMedidaCapacidad,   ");
            select.Append(" TO_CHAR((TIEMPOS_QM.MESQ_POSTIME_NB - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaCargue,   ");
            select.Append(" TO_CHAR((TIEMPOS_QM.MESQ_POSTIME_NB - 0.18 / 24), 'HH24:MI') horaLlegadaCargueRemesa,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM.MESQ_POSTIME_NB, 'DD/MM/YYYY') fechaEntradaCargue,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM.MESQ_POSTIME_NB /*+ (0.18/24)*/, 'HH24:MI') horaEntradaCargueRemesa,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A1.MESQ_POSTIME_NB, 'DD/MM/YYYY') fechaSalidaCargue,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A1.MESQ_POSTIME_NB /*+ (0.18/24*/, 'HH24:MI') horaSalidaCargueRemesa,   ");
            select.Append(" TO_CHAR((TIEMPOS_QM_A2.MESQ_POSTIME_NB - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaDescargue,   ");
            select.Append(" TO_CHAR((TIEMPOS_QM_A2.MESQ_POSTIME_NB - 0.18 / 24), 'HH24:MI') horaLlegadaDescargueCumplido,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A2.MESQ_POSTIME_NB, 'DD/MM/YYYY') fechaEntradaDescargue,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A2.MESQ_POSTIME_NB /*+ (0.18/24)*/, 'HH24:MI') horaEntradaDescargueCumplido,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A3.MESQ_POSTIME_NB, 'DD/MM/YYYY') fechaSalidaDescargue,   ");
            select.Append(" TO_CHAR(TIEMPOS_QM_A3.MESQ_POSTIME_NB /*+ (0.60/24)*/, 'HH24:MI') horaSalidaDescargueCumplido,   ");
            select.Append(" substr(CUMPLIDOS.CUMP_OBSERVACIONES_V2, 1, 200) observaciones   ");
            select.Append(" FROM TIEMPOS_QM, TIEMPOS_QM TIEMPOS_QM_A1,   ");
            select.Append(" TIEMPOS_QM TIEMPOS_QM_A2, TIEMPOS_QM TIEMPOS_QM_A3,   ");
            select.Append(" ORDENES_CARGUE, VIAJES, CUMPLIDOS   ");
            select.Append(" WHERE TIEMPOS_QM.MESQ_ORDENCARGUE_NB =:llave   ");
            select.Append(" AND TIEMPOS_QM.MESQ_NUMACRO_NB = 2   ");
            select.Append(" AND TIEMPOS_QM_A1.MESQ_NUMACRO_NB = 6   ");
            select.Append(" AND TIEMPOS_QM_A2.MESQ_NUMACRO_NB = 15   ");
            select.Append(" AND TIEMPOS_QM_A3.MESQ_NUMACRO_NB = 19   ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB = TIEMPOS_QM.MESQ_ORDENCARGUE_NB   ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB = TIEMPOS_QM_A1.MESQ_ORDENCARGUE_NB   ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB = TIEMPOS_QM_A3.MESQ_ORDENCARGUE_NB   ");
            select.Append(" AND ORDENES_CARGUE.ORCA_NUMERO_NB = TIEMPOS_QM_A2.MESQ_ORDENCARGUE_NB   ");
            select.Append(" AND VIAJES.VIAJ_ORDCARGUE_NB = ORDENES_CARGUE.ORCA_NUMERO_NB   ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2 = CUMPLIDOS.CUMP_PLANILLA_V2   ");

            //select.Append(" and trunc(VIAJ_FECVIAJE_DT) between trunc(sysdate-360) and trunc(sysdate)   ");

            select.Append(" AND ROWNUM < 2   ");
            select.Append(" group by ORCA_NUMERO_NB, VIAJ_NOPLANILLA_V2, ORCA_VOLUMEN_NB, TIEMPOS_QM.MESQ_POSTIME_NB,   ");
            select.Append(" TIEMPOS_QM_A2.MESQ_NUMACRO_NB, TIEMPOS_QM_A1.MESQ_POSTIME_NB, CUMP_OBSERVACIONES_V2,   ");
            select.Append(" TIEMPOS_QM_A3.MESQ_POSTIME_NB, TIEMPOS_QM_A2.MESQ_POSTIME_NB   ");
            select.Append(" union   ");
            select.Append(" SELECT DISTINCT 8605048823 numNitEmpresaTransporte,   ");
            select.Append(" VIAJES.VIAJ_ORDCARGUE_NB consecutivoRemesa,   ");
            select.Append(" VIAJES.VIAJ_NOPLANILLA_V2 numManifiestoCarga,   ");
            select.Append(" 'C' tipoCumplidoRemesa,   ");
            select.Append(" '' motivoSuspensionRemesa,   ");
            select.Append(" FDB_KDESPACHADOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadCargada,   ");
            select.Append(" FDB_KRECIBIDOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadEntregada,   ");
            select.Append(" DECODE(ORCA_VOLUMEN_NB, 'K', 1, 'V', 1, ORCA_VOLUMEN_NB) unidadMedidaCapacidad,   ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaCargue,   ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT - 0.18 / 24), 'HH24:MI') horaLlegadaCargueRemesa,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT, 'DD/MM/YYYY') fechaEntradaCargue,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT , 'HH24:MI') horaEntradaCargueRemesa,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_TERMINA_DT, 'DD/MM/YYYY') fechaSalidaCargue,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS.CUTI_TERMINA_DT , 'HH24:MI') horaSalidaCargueRemesa,   ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaDescargue,   ");
            select.Append(" TO_CHAR((CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT - 0.18 / 24), 'HH24:MI') horaLlegadaDescargueCumplido,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT, 'DD/MM/YYYY') fechaEntradaDescargue,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT , 'HH24:MI') horaEntradaDescargueCumplido,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_TERMINA_DT, 'DD/MM/YYYY') fechaSalidaDescargue,   ");
            select.Append(" TO_CHAR(CUMPLIDOS_TIEMPOS_A1.CUTI_TERMINA_DT , 'HH24:MI') horaSalidaDescargueCumplido,   ");
            select.Append(" substr(CUMPLIDOS.CUMP_OBSERVACIONES_V2, 1, 200) observaciones   ");
            select.Append(" FROM CUMPLIDOS_TIEMPOS, CUMPLIDOS_TIEMPOS CUMPLIDOS_TIEMPOS_A1, VIAJES, CUMPLIDOS,   ");
            select.Append(" ORDENES_CARGUE   ");
            select.Append(" WHERE CUMPLIDOS_TIEMPOS.CUTI_TIPOCARDES_V2 = 'C'   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS_A1.CUTI_TIPOCARDES_V2 = 'D'   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_SECCUMP_NB = CUMPLIDOS_TIEMPOS_A1.CUTI_SECCUMP_NB   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NEGOCIO_NB = CUMPLIDOS_TIEMPOS_A1.CUTI_NEGOCIO_NB   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_PLANILLA_V2 = CUMPLIDOS_TIEMPOS_A1.CUTI_PLANILLA_V2   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NEGRUTSEC_NB = CUMPLIDOS_TIEMPOS_A1.CUTI_NEGRUTSEC_NB   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NERUCAMINO_NB = CUMPLIDOS_TIEMPOS_A1.CUTI_NERUCAMINO_NB   ");
            select.Append(" AND CUMPLIDOS_TIEMPOS.CUTI_NERURUTA_NB = CUMPLIDOS_TIEMPOS_A1.CUTI_NERURUTA_NB   ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2 = CUMPLIDOS_TIEMPOS.CUTI_PLANILLA_V2   ");
            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2 = CUMPLIDOS.CUMP_PLANILLA_V2   ");
            select.Append(" AND VIAJ_ORDCARGUE_NB = ORCA_NUMERO_NB   ");
            select.Append(" and ORCA_NUMERO_NB =:llave   ");

            //select.Append(" and trunc(VIAJ_FECVIAJE_DT) between trunc(sysdate-360) and trunc(sysdate)   ");


            select.Append(" GROUP BY VIAJES.VIAJ_ORDCARGUE_NB, VIAJES.VIAJ_NOPLANILLA_V2, CUMPLIDOS_TIEMPOS.CUTI_INIICIA_DT,   ");
            select.Append(" CUMPLIDOS_TIEMPOS.CUTI_TERMINA_DT, CUMPLIDOS.CUMP_MEDIDAFALTA_V2, ORCA_VOLUMEN_NB,   ");
            select.Append(" CUMPLIDOS_TIEMPOS_A1.CUTI_INIICIA_DT, CUMPLIDOS_TIEMPOS_A1.CUTI_TERMINA_DT, CUMPLIDOS.CUMP_OBSERVACIONES_V2   ");
            select.Append(" union   ");
            select.Append(" select DISTINCT 8605048823 numNitEmpresaTransporte,   ");
            select.Append(" R.VITI_ORDCARGUE_NB consecutivoRemesa,   ");
            select.Append(" VIAJ_NOPLANILLA_V2 numManifiestoCarga,   ");
            select.Append(" 'C' tipoCumplidoRemesa,   ");
            select.Append(" '' motivoSuspensionRemesa,   ");
            select.Append(" FDB_KDESPACHADOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadCargada,   ");
            select.Append(" FDB_KRECIBIDOSW(VIAJES.VIAJ_NOPLANILLA_V2) cantidadEntregada,   ");
            select.Append(" DECODE(R.ORCA_VOLUMEN_NB, 'K', 1, 'V', 1, R.ORCA_VOLUMEN_NB) unidadMedidaCapacidad,   ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaCargue,   ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT - 0.18 / 24), 'HH24:MI') horaLlegadaCargueRemesa,   ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT), 'DD/MM/YYYY') fechaEntradaCargue,   ");
            select.Append(" TO_CHAR((R.VITI_FECHAENTRADA_DT), 'HH24:MI') horaEntradaCargueRemesa,   ");
            select.Append(" TO_CHAR((R.VITI_FECHASALIDA_DT), 'DD/MM/YYYY') fechaSalidaCargue,   ");
            select.Append(" TO_CHAR((R.VITI_FECHASALIDA_DT), 'HH24:MI') horaSalidaCargueRemesa,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT - 0.18 / 24), 'DD/MM/YYYY') fechaLlegadaDescargue,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT - 0.18 / 24), 'HH24:MI') horaLlegadaDescargueCumplido,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT), 'DD/MM/YYYY') fechaEntradaDescargue,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT), 'HH24:MI') horaEntradaDescargueCumplido,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT), 'DD/MM/YYYY') fechaSalidaDescargue,   ");
            select.Append(" TO_CHAR((D.VITI_FECHAENTRADA_DT), 'HH24:MI') horaSalidaDescargueCumplido,   ");
            select.Append(" substr(CUMPLIDOS.CUMP_OBSERVACIONES_V2, 1, 200) observaciones   ");
            select.Append(" FROM viajes_tiempos R, viajes_tiempos D, ORDENES_CARGUE R, ORDENES_CARGUE D, VIAJES,   ");
            select.Append(" cumplidos   ");
            select.Append(" WHERE R.VITI_ORDCARGUE_NB = R.ORCA_NUMERO_NB   ");
            select.Append(" AND R.VITI_PLANTA_NB = R.ORCA_PLANTAREMITE_NB   ");
            select.Append(" AND D.VITI_ORDCARGUE_NB = D.ORCA_NUMERO_NB   ");
            select.Append(" AND D.VITI_PLANTA_NB = D.ORCA_PLANTARECIBE_NB   ");
            select.Append(" AND R.VITI_ORDCARGUE_NB = D.VITI_ORDCARGUE_NB   ");
            select.Append(" AND D.VITI_ORDCARGUE_NB =:llave   ");
            select.Append(" AND D.VITI_ORDCARGUE_NB = VIAJ_ORDCARGUE_NB   ");

            //select.Append(" and trunc(VIAJ_FECVIAJE_DT) between trunc(sysdate-360) and trunc(sysdate)   ");

            select.Append(" AND VIAJES.VIAJ_NOPLANILLA_V2 = CUMPLIDOS.CUMP_PLANILLA_V2; ");
            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_PROPIETARIOS_NIT()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT '8605048823' numNitEmpresaTransporte,PROP_TIPOIDEN_V2 codTipoIdTercero,PROP_CEDULA_NB||decode(length(PROP_CEDULA_NB),10,null,9,f_chequeonit(PROP_CEDULA_NB,1),null) numIdTercero, ");
            select.Append(" PROP_NOMBRE_V2 nomIdTercero,'.' primerApellidoIdTercero,',' segundoApellidoIdTercero,PROP_TELEFONO_NB numTelefonoContacto, ");
            select.Append(" substr(PROP_DIRECCION_V2,1,60) nomenclaturaDireccion,substr(CIUD_DIVIPOLA_CH,1,8) codMunicipioRndc,'1' codSedeTercero, ");
            select.Append(" 'PRINCIPAL' nomSedeTercero ");
            select.Append(" from propietarios,ciudades ");
            select.Append(" where PROP_TIPOIDEN_V2='N' ");
            select.Append(" and PROP_CIUDRES_NB=CIUD_CODIGO_NB ");
            select.Append(" and PROP_CEDULA_NB=:llave; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_PROPIETARIOS_CEDULA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT '8605048823' numNitEmpresaTransporte, ");
            select.Append(" PROP_TIPOIDEN_V2 codTipoIdTercero, ");
            select.Append(" to_char(PROP_CEDULA_NB) numIdTercero, ");
            select.Append(" PROP_NOMBRE_V2 nomIdTercero, ");
            select.Append(" FDB_PRIMERAPELLIDOPRO(PROP_CEDULA_NB) primerApellidoIdTercero, ");
            select.Append(" FDB_SEGUNDOAPELLIDOPRO(PROP_CEDULA_NB) segundoApellidoIdTercero ");
            select.Append(" /*rpad(decode(substr(substr(PROP_APELLIDO_V2,1,instr(PROP_APELLIDO_V2,' ',1)),1,12), ");
            select.Append(" null,PROP_APELLIDO_V2,substr(substr(PROP_APELLIDO_V2,1,instr(PROP_APELLIDO_V2,' ',1)),1,12)),12) ");
            select.Append(" primerApellidoIdTercero, ");
            select.Append(" rpad(decode(instr(PROP_APELLIDO_V2,' ',1),0,rpad(chr(32),12),substr(PROP_APELLIDO_V2, ");
            select.Append(" instr(PROP_APELLIDO_V2,' ',1)+1,12)),12) segundoApellidoIdTercero*/, ");
            select.Append(" PROP_TELEFONO_NB numTelefonoContacto, ");
            select.Append(" substr(PROP_DIRECCION_V2,1,60) nomenclaturaDireccion,substr(CIUD_DIVIPOLA_CH,1,8) codMunicipioRndc, ");
            select.Append(" '1' codSedeTercero, ");
            select.Append(" 'PRINCIPAL' nomSedeTercero ");
            select.Append(" from propietarios,ciudades ");
            select.Append(" where PROP_TIPOIDEN_V2<>'N' ");
            select.Append(" and PROP_CIUDRES_NB=CIUD_CODIGO_NB ");
            select.Append(" and PROP_CEDULA_NB=:llave ");
            select.Append(" order by PROP_CEDULA_NB; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_CONDUCTORES()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' NUMNITEMPRESATRANSPORTE, ");
            select.Append(" COND_TIPOIDEN_V2 codTipoIdTercero, ");
            select.Append(" COND_CEDULA_NB numIdTercero, ");
            select.Append(" COND_NOMBRE_V2 nomIdTercero, ");
            //select.Append(" /*rpad(decode(substr(substr(COND_APELLIDO_V2,1,instr(COND_APELLIDO_V2,' ',1)),1,12), ");
            //select.Append(" null,COND_APELLIDO_V2,substr(substr(COND_APELLIDO_V2,1,instr(COND_APELLIDO_V2,' ',1)),1,12)),12)*/ ");
            select.Append(" FDB_PRIMERAPELLIDO(COND_CEDULA_NB) primerApellidoIdTercero, ");
            //select.Append(" /*rpad(decode(instr(COND_APELLIDO_V2,' ',1),0,rpad(chr(32),12),substr(COND_APELLIDO_V2,instr(COND_APELLIDO_V2,' ',1)+1,12)),12)*/ ");
            select.Append(" FDB_SEGUNDOAPELLIDO(COND_CEDULA_NB) segundoApellidoIdTercero, ");
            select.Append(" COND_TELEFONO_NB numTelefonoContacto, ");
            select.Append(" substr(COND_DIRECCION_V2,1,60) nomenclaturaDireccion, ");
            select.Append(" substr(CIUD_DIVIPOLA_CH,1,8) codMunicipioRndc, ");
            select.Append(" 0 codSedeTercero, ");
            select.Append(" 'PRINCIPAL' nomSedeTercero, ");
            select.Append(" COND_NOLICEN_NB numLicenciaConduccion, ");
            select.Append(" COND_CATEGORIA_V2 codCategoriaLicenciaConduccion, ");
            //select.Append(" ---DECODE(COND_CATEG_,7,'C1',8,'C2',9,'C3',2,4,3,4,COND_CATEG_) codCategoriaLicenciaConduccion, ");
            select.Append(" to_char(COND_FECVENTO_DT,'DD/MM/YYYY') fechaVencimientoLicencia ");
            select.Append(" from conductores,ciudades ");
            select.Append(" where COND_CIUDAD_NB=CIUD_CODIGO_NB ");
            //select.Append(" --- and COND_ESTADO_V2='A' ");
            select.Append(" and COND_CEDULA_NB = :LLAVE ");
            select.Append(" order by COND_CEDULA_NB; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_CLIENTES_NIT()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' numNitEmpresaTransporte, ");
            select.Append(" CLIE_TIPOIDENT codTipoIdTercero, ");
            select.Append(" CLIE_NIT_NB||decode(length(CLIE_NIT_NB),10,null,9,f_chequeonit(CLIE_NIT_NB,1),null) numIdTercero, ");
            select.Append(" CLIE_NOMBRE_V2 nomIdTercero, ");
            select.Append(" CLIE_TELEFONO_1_NB numTelefonoContacto, ");
            select.Append(" substr(CLIE_DIRECCION_V2,1,60) nomenclaturaDireccion, ");
            select.Append(" CIUD_DIVIPOLA_CH codMunicipioRndc, ");
            select.Append(" CIPA_PLANTA_NB codSedeTercero, ");
            select.Append(" PLAN_NOMBRE_V2 nomSedeTercero, ");
            select.Append(" substr(PLAN_CAMPO2_V2,1,instr(PLAN_CAMPO2_V2,':',1)-1) latitud, ");
            select.Append(" SUBSTR(PLAN_CAMPO2_V2,(INSTR(PLAN_CAMPO2_V2,':',1)+1),15) longitud ");
            select.Append(" FROM CLIENTES,PLANTAS,CIUDADES,CLIENTES_PLANTAS ");
            select.Append(" WHERE CIPA_CLIENTE_NB=CLIE_CODIGO_NB ");
            select.Append(" AND PLAN_CODIGO_NB=CIPA_PLANTA_NB ");
            select.Append(" AND PLAN_CIUDAD_NB=CIUD_CODIGO_NB ");
            select.Append(" and CLIE_TIPOIDENt='N' ");
            select.Append(" and CIPA_ESTADO_V2='A' ");
            select.Append(" AND PLAN_CAMPO2_V2 IS NOT NULL ");
            select.Append(" AND PLAN_CODIGO_NB=:llave ");
            select.Append(" order by CLIE_NIT_NB; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_CLIENTES_CEDULA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' numNitEmpresaTransporte, ");
            select.Append(" CLIE_TIPOIDENt codTipoIdTercero, ");
            select.Append(" CLIE_NIT_NB numIdTercero, ");
            select.Append(" CLIE_NOMBRE_V2 nomIdTercero, ");
            select.Append(" CLIE_APELLIDO1  primerApellidoIdTercero, ");
            select.Append(" CLIE_APELLIDO2 segundoApellidoIdTercero, ");
            select.Append(" CLIE_TELEFONO_1_NB numTelefonoContacto, ");
            //select.Append(" --PLAN_DIRECCION_V2 TERDIRECCION, ");
            select.Append(" substr(CLIE_DIRECCION_V2,1,60) nomenclaturaDireccion, ");
            select.Append(" CIUD_DIVIPOLA_CH codMunicipioRndc, ");
            select.Append(" CIPA_PLANTA_NB codSedeTercero, ");
            select.Append(" PLAN_NOMBRE_V2 nomSedeTercero, ");
            select.Append(" substr(PLAN_CAMPO2_V2,1,instr(PLAN_CAMPO2_V2,':',1)-1) latitud, ");
            select.Append(" SUBSTR(PLAN_CAMPO2_V2,(INSTR(PLAN_CAMPO2_V2,':',1)+1),15) longitud ");
            select.Append(" FROM CLIENTES,PLANTAS,CIUDADES,CLIENTES_PLANTAS ");
            select.Append(" WHERE CIPA_CLIENTE_NB=CLIE_CODIGO_NB ");
            select.Append(" AND PLAN_CODIGO_NB=CIPA_PLANTA_NB ");
            select.Append(" AND PLAN_CIUDAD_NB=CIUD_CODIGO_NB ");
            select.Append(" AND PLAN_CODIGO_NB=:llave ");
            select.Append(" and CLIE_TIPOIDENT<>'N' ");
            select.Append(" order by CLIE_NIT_NB; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_VEHICULOS()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT distinct VEHICULOS.VEHI_PLACA_CH numPlaca, ");
            select.Append(" DECODE(VEHI_CONFIGURACION_V2,'1','50','2','50','3','51','4','52','5','56','2S','53','3S','54','4S','55',NULL) codConfiguracionUnidadCarga, ");
            select.Append(" MARC_MIN_V2 codMarcaVehiculoCarga, ");
            select.Append(" LIVE_LINMIN_V2 codLineaVehiculoCarga, ");
            select.Append(" VEHI_NOEJES_NB numEjes, ");
            select.Append(" VEHI_MODELO_V2 anoFabricacionVehiculoCarga, ");
            select.Append(" VEHICULOS.VEHI_MODELOREPO_NB anoRepotenciacion, ");
            select.Append(" COLO_MIN_V2 codColorVehiculoCarga, ");
            select.Append(" VEHICULOS.VEHI_PESOVACIO_NB pesoVehiculoVacio, ");
            select.Append(" VEHI_CAPACIDAD_NB capacidadUnidadCarga, ");
            select.Append(" 1 unidadMedidaCapacidad, ");
            select.Append(" DECODE(CLVE_TIPO_V2,'A','0','R',(DECODE(VEHI_CLASE_NB,3,1,2,2,51,2,10,1,54,3,0))) codTipoCarroceria, ");
            select.Append(" VEHI_NOSERIE_V2 numChasis, ");
            select.Append(" 1 codTipoCombustible, ");
            select.Append(" DOCUMENTOS_VEHICULO.DOVE_NODOCUMENTO_NB numSeguroSoat, ");
            select.Append(" to_char(DOCUMENTOS_VEHICULO.DOVE_FECVENCE_DT,'DD/MM/YYYY') fechaVencimientoSoat, ");
            select.Append(" EMPRESAS.EMPR_NIT_NB||f_chequeonit(EMPR_NIT_NB,1) numNitAseguradoraSoat, ");
            select.Append(" PROPIETARIOS.PROP_TIPOIDEN_V2 codTipoIdPropietario, ");
            select.Append(" decode(propietarios.PROP_TIPOIDEN_V2,'C',ENLA_PROPIETARIO_NB,'N',ENLA_PROPIETARIO_NB|| ");
            select.Append(" (decode(length(ENLA_PROPIETARIO_NB),10,null,9,f_chequeonit(ENLA_PROPIETARIO_NB,1),NULL))) numIdPropietario, ");
            //select.Append(" ----ENLACE.ENLA_PROPIETARIO_NB||decode(length(ENLA_PROPIETARIO_NB),10,null,9,f_chequeonit(ENLA_PROPIETARIO_NB,1),null) numIdPropietario, ");
            select.Append(" PROPIETARIOS_A1.PROP_TIPOIDEN_V2 codTipoIdTenedor, ");
            select.Append(" ENLACE.ENLA_POSEEDOR_NB||decode(length(ENLA_POSEEDOR_NB),10,null,9,f_chequeonit(ENLA_POSEEDOR_NB,1),null) numIdTenedor, ");
            select.Append(" 8605048823 NUMNITEMPRESATRANSPORTE ");
            select.Append(" FROM VEHICULOS,PROPIETARIOS,ENLACE,PROPIETARIOS PROPIETARIOS_A1,DOCUMENTOS_VEHICULO, ");
            select.Append(" LICENCIAS_DOCUMENTOS,EMPRESAS,marcas,LINEAS_VEHICULO,COLORES,CLASE_VEHICULO ");
            select.Append(" WHERE VEHICULOS.VEHI_PLACA_CH=ENLACE.ENLA_PLACA_CH ");
            select.Append(" AND LICENCIAS_DOCUMENTOS.LIDO_DESCRIPCION_V2='SOAT' ");
            select.Append(" AND DOCUMENTOS_VEHICULO.DOVE_PLACA_CH=VEHICULOS.VEHI_PLACA_CH ");
            select.Append(" AND DOCUMENTOS_VEHICULO.DOVE_DOCLICEN_NB(+)=LICENCIAS_DOCUMENTOS.LIDO_CODIGO_NB ");
            select.Append(" AND DOCUMENTOS_VEHICULO.DOVE_ENTEEXPIDE_NB=EMPRESAS.EMPR_CODIGO_NB ");
            select.Append(" AND ENLACE.ENLA_PROPIETARIO_NB=PROPIETARIOS.PROP_CEDULA_NB ");
            select.Append(" AND ENLACE.ENLA_POSEEDOR_NB=PROPIETARIOS_A1.PROP_CEDULA_NB ");
            select.Append(" AND VEHI_MARCA_V2=MARC_SECUENCIA_NB ");
            select.Append(" AND VEHI_LINEA_NB=LIVE_CODIGO_NB ");
            select.Append(" AND LIVE_MARCA_NB=MARC_SECUENCIA_NB ");
            select.Append(" AND VEHI_COLOR_V2=COLO_CODIGO_NB ");
            select.Append(" AND VEHI_CLASE_NB=CLVE_SECUENCIA_NB ");
            select.Append(" AND VEHICULOS.VEHI_PLACA_CH = :llave ");
            select.Append(" AND DOVE_ESTADO_V2='A' ");
            select.Append(" order by VEHICULOS.VEHI_PLACA_CH; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_TRAILERS()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" SELECT DISTINCT '8605048823' NUMNITEMPRESATRANSPORTE,   ");
            select.Append(" TRAI_PLACA_CH numPlaca,   ");
            select.Append(" DECODE(TRAI_NOEJES_NB,2,62,3,63,TRAI_NOEJES_NB) codConfiguracionUnidadCarga,   ");
            select.Append(" MARC_CAMPO4_V2 codMarcaVehiculoCarga,   ");
            select.Append(" TRAI_MODELO_NB anoFabricacionVehiculoCarga,   ");
            select.Append(" PROPIETARIOS.PROP_TIPOIDEN_V2 codTipoIdPropietario,   ");
            select.Append(" PROPIETARIOS.PROP_CEDULA_NB||decode(length(PROPIETARIOS.PROP_CEDULA_NB),10,null,9,f_chequeonit(PROPIETARIOS.PROP_CEDULA_NB,1),null) numIdPropietario,   ");
            select.Append(" PROPIETARIOS_A1.PROP_TIPOIDEN_V2 codTipoIdTenedor,   ");
            select.Append(" PROPIETARIOS_A1.PROP_CEDULA_NB||decode(length(PROPIETARIOS_A1.PROP_CEDULA_NB),10,null,9,f_chequeonit(PROPIETARIOS_A1.PROP_CEDULA_NB,1),null) numIdTenedor,   ");
            select.Append(" TRAI_PESO_NB pesoVehiculoVacio,   ");
            select.Append(" GENE_DESCRIPCION2_V2 codTipoCarroceria   ");
            select.Append(" FROM TRAILERS, ENLACE,PROPIETARIOS, PROPIETARIOS PROPIETARIOS_A1,MARCAS,GENERICAS   ");
            select.Append(" WHERE TRAILERS.TRAI_PLACA_CH=ENLACE.ENLA_TRAILER_CH   ");
            select.Append(" AND TRAILERS.TRAI_PROPIET_NB=PROPIETARIOS.PROP_CEDULA_NB   ");
            select.Append(" AND PROPIETARIOS_A1.PROP_CEDULA_NB=ENLACE.ENLA_POSEEDOR_NB   ");
            select.Append(" AND TRAI_MARCA_V2=MARC_SECUENCIA_NB   ");
            select.Append(" AND TRAI_TIPO_NB=GENE_CODIGO_NB   ");
            select.Append(" AND GENE_NOMBRE_V2 ='TIPO CARROCERIA'   ");
            select.Append(" AND TRAILERS.TRAI_PLACA_CH = :llave   ");
            select.Append(" UNION   ");
            select.Append(" SELECT DISTINCT '8605048823' NUMNITEMPRESATRANSPORTE,   ");
            select.Append(" TRAILERS.TRAI_PLACA_CH numPlaca,   ");
            select.Append(" DECODE(TRAI_NOEJES_NB,2,62,3,63,TRAI_NOEJES_NB) codConfiguracionUnidadCarga,   ");
            select.Append(" MARC_CAMPO4_V2 codMarcaVehiculoCarga,   ");
            select.Append(" TRAI_MODELO_NB anoFabricacionVehiculoCarga,   ");
            select.Append(" PROP_TIPOIDEN_V2 codTipoIdPropietario,   ");
            select.Append(" PROP_CEDULA_NB||decode(length(PROPIETARIOS.PROP_CEDULA_NB),10,null,9,f_chequeonit(PROPIETARIOS.PROP_CEDULA_NB,1),null) numIdPropietario,   ");
            select.Append(" PROP_TIPOIDEN_V2 codTipoIdTenedor,   ");
            select.Append(" PROP_CEDULA_NB||decode(length(PROPIETARIOS.PROP_CEDULA_NB),10,null,9,f_chequeonit(PROPIETARIOS.PROP_CEDULA_NB,1),null) numIdTenedor,   ");
            select.Append(" TRAI_PESO_NB pesoVehiculoVacio,   ");
            select.Append(" GENE_DESCRIPCION2_V2 codTipoCarroceria   ");
            select.Append(" FROM TRAILERS,PROPIETARIOS,MARCAS,GENERICAS   ");
            select.Append(" WHERE TRAILERS.TRAI_PROPIET_NB=PROPIETARIOS.PROP_CEDULA_NB   ");
            select.Append(" AND TRAI_MARCA_V2=MARC_SECUENCIA_NB   ");
            select.Append(" AND TRAI_TIPO_NB=GENE_CODIGO_NB   ");
            select.Append(" AND GENE_NOMBRE_V2 ='TIPO CARROCERIA'   ");
            select.Append(" AND TRAILERS.TRAI_PLACA_CH = :llave;   ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_ANULAR_MANIFIESTO()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' numNitEmpresaTransporte, ");
            select.Append(" VIAJ_NOPLANILLA_V2 numManifiestoCarga,'S' motivoAnulacionManifiesto, ");
            select.Append(" GENE_DESCRIPCION_V2 OBSERVACIONES ");
            select.Append(" FROM VIAJES,genericas ");
            select.Append(" WHERE GENE_NOMBRE_V2='CAUSA ANULA PLANILLA' ");
            select.Append(" and VIAJ_CAUSANULA_NB=GENE_CODIGO_NB ");
            select.Append(" and VIAJ_NOPLANILLA_V2=:LLAVE; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string PK_MINISTERIO_XML_ANULAR_REMESA()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare  ");
            select.Append(" begin  ");
            select.Append(" open :refcur1 for   ");

            select.Append(" select '8605048823' numNitEmpresaTransporte,'A' motivoReversaRemesa, ");
            select.Append(" 'S' motivoAnulacionRemesa,ORCA_NUMERO_NB consecutivoRemesa ");
            select.Append(" from ordenes_cargue ");
            select.Append(" where ORCA_NUMERO_NB=:llave; ");

            select.Append(" end; ");
            return select.ToString();
        }
        private string InsertDetLogMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" insert into det_log_ministerio (DELM_SECUENCIA_NB, ");
            select.Append(" DELM_LOGSECUENCIA_NB, ");
            select.Append(" DELM_OFICINA_NB, ");
            select.Append(" DELM_TRANSACCION_NB, ");
            select.Append(" DELM_LLAVE_V2, ");
            select.Append(" DELM_ESTADO_V2, ");
            select.Append(" DELM_IDMINISTERIO_NB, ");
            select.Append(" DELM_XMLENVIADO_XML, ");
            select.Append(" DELM_FECENVIO_DT, ");
            select.Append(" DELM_XMLRECIBIDO_XML, ");
            select.Append(" DELM_CAMPO1_NB, ");
            select.Append(" DELM_CAMPO2_V2, ");
            select.Append(" DELM_CAMPO3_DT) ");
            select.Append(" values(:secuencia, ");
            select.Append(" :LRMI_SECUENCIA_NB, ");
            select.Append(" :LRMI_OFICINA_NB, ");
            select.Append(" :LRMI_TRANSACCION_NB, ");
            select.Append(" :LRMI_LLAVE_V2, ");
            select.Append(" :LRMI_ESTADO_V2, ");
            select.Append(" :DELM_IDMINISTERIO_NB, ");
            select.Append(" :DELM_XMLENVIADO_XML, ");
            select.Append(" sysdate, ");
            select.Append(" :DELM_XMLRECIBIDO_XML, ");
            select.Append(" null, ");
            select.Append(" null, ");
            select.Append(" null); ");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string getDetLogMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DELM_SECUENCIA_NB, ");
            select.Append(" DELM_LOGSECUENCIA_NB, ");
            select.Append(" DELM_OFICINA_NB, ");
            select.Append(" DELM_TRANSACCION_NB, ");
            select.Append(" DELM_LLAVE_V2, ");
            select.Append(" DELM_ESTADO_V2, ");
            select.Append(" DELM_IDMINISTERIO_NB, ");
            select.Append(" DELM_XMLENVIADO_XML, ");
            select.Append(" DELM_FECENVIO_DT, ");
            select.Append(" DELM_XMLRECIBIDO_XML, ");
            select.Append(" DELM_CAMPO1_NB, ");
            select.Append(" DELM_CAMPO2_V2, ");
            select.Append(" DELM_CAMPO3_DT ");
            select.Append(" from det_log_ministerio ");
            select.Append(" where DELM_LOGSECUENCIA_NB =:LRMI_SECUENCIA_NB ");
            select.Append(" and DELM_OFICINA_NB =:LRMI_OFICINA_NB ");
            select.Append(" order by DELM_SECUENCIA_NB; ");
            select.Append("end;");
            return select.ToString();
        }
        private string UpdateLogReporteMinisterio()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_ministerio set ");
            select.Append(" LRMI_ESTADO_V2 =:LRMI_ESTADO, ");
            select.Append(" LRMI_CAMPO1_NB =:LRMI_CAMPO1 ");
            select.Append(" where LRMI_SECUENCIA_NB =:LRMI_SECUENCIA ");
            select.Append(" and LRMI_OFICINA_NB =:LRMI_OFICINA; ");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string UpdateLogReporteMinisterioCampo1()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" update log_reporte_ministerio set ");
            select.Append(" LRMI_ESTADO_V2 =:LRMI_ESTADO, ");
            select.Append(" LRMI_CAMPO1_NB =:LRMI_CAMPO1 ");
            select.Append(" where LRMI_SECUENCIA_NB =:LRMI_SECUENCIA ");
            select.Append(" and LRMI_OFICINA_NB =:LRMI_OFICINA; ");
            select.Append(" end;  ");
            return select.ToString();
        }
        private string getInfoLogReporteBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select REBA_SECUENCIA_NB, ");
            select.Append(" REBA_OFICINA_NB, ");
            select.Append(" REBA_TRANSACCION_NB, ");
            select.Append(" REBA_LLAVE_V2, ");
            select.Append(" REBA_FECHA_DT, ");
            select.Append(" REBA_ESTADO_V2, ");
            select.Append(" REBA_CAMPO1_NB, ");
            select.Append(" REBA_CAMPO2_DT, ");
            select.Append(" REBA_CAMPO3_V2 ");
            select.Append(" from log_reporte_bavaria ");
            select.Append(" where trunc(REBA_FECHA_DT) between trunc(sysdate-400) and trunc(sysdate) ");
            select.Append(" order by REBA_SECUENCIA_NB; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getDetalleDetLogBavaria()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select DEBA_SECUENCIA_NB, ");
            select.Append(" DEBA_LOGBAVARIA_NB, ");
            select.Append(" DEBA_OFICINA_NB, ");
            select.Append(" DEBA_TRANSACCION_NB, ");
            select.Append(" DEBA_LLAVE_V2, ");
            select.Append(" DEBA_NUMACEPTA_NB, ");
            select.Append(" DEBA_ESTADO_V2, ");
            select.Append(" DEBA_SOAPENVIADO_V2, ");
            select.Append(" DEBA_SOAPRECIBIDO_V2, ");
            select.Append(" DEBA_FECPROCESA_DT, ");
            select.Append(" DEBA_CAMPO1_NB, ");
            select.Append(" DEBA_CAMPO2_DT, ");
            select.Append(" DEBA_CAMPO3_V2 ");
            select.Append(" from det_log_bavaria ");
            select.Append(" where DEBA_LOGBAVARIA_NB =:DEBA_LOGBAVARIA ");
            select.Append(" and DEBA_OFICINA_NB =:DEBA_OFICINA ");
            select.Append(" and DEBA_LLAVE_V2 =:DEBA_LLAVE ");
            select.Append(" order by DEBA_SECUENCIA_NB; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getUrbanos()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB, ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" LRMI_CAMPO1_NB, ");
            select.Append(" LRMI_CAMPO2_V2, ");
            select.Append(" LRMI_CAMPO3_DT ");
            select.Append(" from log_reporte_ministerio ");
            select.Append(" where trunc(LRMI_FECREGISTRO_DT) between trunc(sysdate - 3) and trunc(sysdate) ");
            select.Append(" and LRMI_TRANSACCION_NB in (3, 4, 5, 6, 32) ");
            select.Append(" order by 3; ");
            select.Append("end;");
            return select.ToString();
        }
        private string getUpdateUrbanos()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" iguales number(3); ");
            select.Append(" cursor c_urbanos is ");
            select.Append(" select * ");
            select.Append(" from log_reporte_ministerio ");
            select.Append(" where LRMI_TRANSACCION_NB in (3, 4, 5, 6, 9, 32) ");
            select.Append(" AND trunc(LRMI_FECREGISTRO_DT) between trunc(sysdate-1) and trunc(sysdate) ");
            //select.Append(" AND LRMI_SECUENCIA_NB < 2748802");
            select.Append(" AND LRMI_ESTADO_V2 in ('R', 'P') ");
            //select.Append(" AND LRMI_ESTADO_V2 in ('P') ");
            select.Append(" order by LRMI_TRANSACCION_NB,LRMI_SECUENCIA_NB; ");
            select.Append(" begin");
            select.Append("     iguales:=-1; ");
            select.Append("     For a in C_URBANOS LOOP    ");
            select.Append("     if (a.LRMI_TRANSACCION_NB = 3) then ");
            select.Append("         SELECT COUNT(1) into iguales ");
            select.Append("         FROM ORDENES_CARGUE, RUTAS, CIUDADES, CIUDADES CIUDADES_A1 ");
            select.Append("         WHERE ORCA_NUMERO_NB = a.LRMI_LLAVE_V2 ");
            select.Append("         AND ORCA_RUTA_NB = RUTA_CODIGO_NB ");
            select.Append("         AND ORDENES_CARGUE.ORCA_RUTA_NB = RUTAS.RUTA_CODIGO_NB ");
            select.Append("         AND RUTAS.RUTA_ORIGEN_NB = CIUDADES.CIUD_CODIGO_NB ");
            select.Append("         AND RUTAS.RUTA_DESTINO_NB = CIUDADES_A1.CIUD_CODIGO_NB ");
            select.Append("         AND CIUDADES.CIUD_DIVIPOLA_CH = CIUDADES_A1.CIUD_DIVIPOLA_CH; ");
            select.Append("         if iguales > 0 then ");
            select.Append("             UPDATE log_reporte_ministerio ");
            select.Append("             SET LRMI_ESTADO_V2 = 'U' ");
            select.Append("             WHERE LRMI_LLAVE_V2 = a.LRMI_LLAVE_V2 ");
            select.Append("             AND LRMI_OFICINA_NB = a.LRMI_OFICINA_NB ");
            select.Append("             AND LRMI_SECUENCIA_NB = a.LRMI_SECUENCIA_NB ");
            select.Append("             AND LRMI_TRANSACCION_NB = a.LRMI_TRANSACCION_NB; ");
            select.Append("         end if; ");
            select.Append("     end if; ");
            select.Append("     if (a.LRMI_TRANSACCION_NB = 5) then ");
            select.Append("         SELECT COUNT(1) into iguales ");
            select.Append("         FROM ORDENES_CARGUE, RUTAS, CIUDADES, CIUDADES CIUDADES_A1 ");
            select.Append("         WHERE ORCA_NUMERO_NB = a.LRMI_LLAVE_V2 ");
            select.Append("         AND ORCA_RUTA_NB = RUTA_CODIGO_NB ");
            select.Append("         AND ORDENES_CARGUE.ORCA_RUTA_NB = RUTAS.RUTA_CODIGO_NB ");
            select.Append("         AND RUTAS.RUTA_ORIGEN_NB = CIUDADES.CIUD_CODIGO_NB ");
            select.Append("         AND RUTAS.RUTA_DESTINO_NB = CIUDADES_A1.CIUD_CODIGO_NB ");
            select.Append("         AND CIUDADES.CIUD_DIVIPOLA_CH = CIUDADES_A1.CIUD_DIVIPOLA_CH; ");
            select.Append("         if iguales > 0 then ");
            select.Append("             UPDATE log_reporte_ministerio ");
            select.Append("             SET LRMI_ESTADO_V2 = 'U' ");
            select.Append("             WHERE LRMI_LLAVE_V2 = a.LRMI_LLAVE_V2 ");
            select.Append("             AND LRMI_OFICINA_NB = a.LRMI_OFICINA_NB ");
            select.Append("             AND LRMI_SECUENCIA_NB = a.LRMI_SECUENCIA_NB ");
            select.Append("             AND LRMI_TRANSACCION_NB = a.LRMI_TRANSACCION_NB; ");
            select.Append("         end if; ");
            select.Append("     end if; ");
            select.Append("     if (a.LRMI_TRANSACCION_NB = 4) then ");
            select.Append("         SELECT COUNT(1) into iguales ");
            select.Append("         FROM ORDENES_CARGUE, RUTAS, CIUDADES, CIUDADES CIUDADES_A1,VIAJES ");
            select.Append("         WHERE ORCA_NUMERO_NB = VIAJ_ORDCARGUE_NB ");
            select.Append("         AND ORCA_RUTA_NB = RUTA_CODIGO_NB ");
            select.Append("         AND ORDENES_CARGUE.ORCA_RUTA_NB = RUTAS.RUTA_CODIGO_NB ");
            select.Append("         AND RUTAS.RUTA_ORIGEN_NB = CIUDADES.CIUD_CODIGO_NB ");
            select.Append("         AND RUTAS.RUTA_DESTINO_NB = CIUDADES_A1.CIUD_CODIGO_NB ");
            select.Append("         AND CIUDADES.CIUD_DIVIPOLA_CH = CIUDADES_A1.CIUD_DIVIPOLA_CH ");
            select.Append("         AND VIAJ_NOPLANILLA_V2 = a.LRMI_LLAVE_V2; ");
            select.Append("         if (iguales > 0) then ");
            select.Append("             UPDATE log_reporte_ministerio ");
            select.Append("             SET LRMI_ESTADO_V2 = 'U' ");
            select.Append("             WHERE LRMI_LLAVE_V2 = a.LRMI_LLAVE_V2 ");
            select.Append("             AND LRMI_OFICINA_NB = a.LRMI_OFICINA_NB ");
            select.Append("             AND LRMI_SECUENCIA_NB = a.LRMI_SECUENCIA_NB ");
            select.Append("             AND LRMI_TRANSACCION_NB = a.LRMI_TRANSACCION_NB; ");
            select.Append("         end if; ");
            select.Append("     end if; ");
            select.Append("     if (a.LRMI_TRANSACCION_NB = 6) then ");
            select.Append("         SELECT COUNT(1) into iguales ");
            select.Append("         FROM ORDENES_CARGUE, RUTAS, CIUDADES, CIUDADES CIUDADES_A1,VIAJES ");
            select.Append("         WHERE ORCA_NUMERO_NB = VIAJ_ORDCARGUE_NB ");
            select.Append("         AND ORCA_RUTA_NB = RUTA_CODIGO_NB ");
            select.Append("         AND ORDENES_CARGUE.ORCA_RUTA_NB = RUTAS.RUTA_CODIGO_NB ");
            select.Append("         AND RUTAS.RUTA_ORIGEN_NB = CIUDADES.CIUD_CODIGO_NB ");
            select.Append("         AND RUTAS.RUTA_DESTINO_NB = CIUDADES_A1.CIUD_CODIGO_NB ");
            select.Append("         AND CIUDADES.CIUD_DIVIPOLA_CH = CIUDADES_A1.CIUD_DIVIPOLA_CH ");
            select.Append("         AND VIAJ_NOPLANILLA_V2 = a.LRMI_LLAVE_V2; ");
            select.Append("         if (iguales > 0) then ");
            select.Append("             UPDATE log_reporte_ministerio ");
            select.Append("             SET LRMI_ESTADO_V2 = 'U' ");
            select.Append("             WHERE LRMI_LLAVE_V2 = a.LRMI_LLAVE_V2 ");
            select.Append("             AND LRMI_OFICINA_NB = a.LRMI_OFICINA_NB ");
            select.Append("             AND LRMI_SECUENCIA_NB = a.LRMI_SECUENCIA_NB ");
            select.Append("             AND LRMI_TRANSACCION_NB = a.LRMI_TRANSACCION_NB; ");
            select.Append("         end if; ");
            select.Append("     end if; ");
            select.Append("     if (a.LRMI_TRANSACCION_NB = 32) then ");
            select.Append("         SELECT COUNT(1) into iguales ");
            select.Append("         FROM ORDENES_CARGUE, RUTAS, CIUDADES, CIUDADES CIUDADES_A1,VIAJES ");
            select.Append("         WHERE ORCA_NUMERO_NB = VIAJ_ORDCARGUE_NB ");
            select.Append("         AND ORCA_RUTA_NB = RUTA_CODIGO_NB ");
            select.Append("         AND ORDENES_CARGUE.ORCA_RUTA_NB = RUTAS.RUTA_CODIGO_NB ");
            select.Append("         AND RUTAS.RUTA_ORIGEN_NB = CIUDADES.CIUD_CODIGO_NB ");
            select.Append("         AND RUTAS.RUTA_DESTINO_NB = CIUDADES_A1.CIUD_CODIGO_NB ");
            select.Append("         AND CIUDADES.CIUD_DIVIPOLA_CH = CIUDADES_A1.CIUD_DIVIPOLA_CH ");
            select.Append("         AND VIAJ_NOPLANILLA_V2 = a.LRMI_LLAVE_V2; ");
            select.Append("         if (iguales > 0) then ");
            select.Append("             UPDATE log_reporte_ministerio ");
            select.Append("             SET LRMI_ESTADO_V2 = 'U' ");
            select.Append("             WHERE LRMI_LLAVE_V2 = a.LRMI_LLAVE_V2 ");
            select.Append("             AND LRMI_OFICINA_NB = a.LRMI_OFICINA_NB ");
            select.Append("             AND LRMI_SECUENCIA_NB = a.LRMI_SECUENCIA_NB ");
            select.Append("             AND LRMI_TRANSACCION_NB = a.LRMI_TRANSACCION_NB; ");
            select.Append("         end if; ");
            select.Append("     end if; ");
            select.Append("     end loop; ");
            select.Append(" commit; ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB, ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" LRMI_CAMPO1_NB, ");
            select.Append(" LRMI_CAMPO2_V2, ");
            select.Append(" LRMI_CAMPO3_DT ");
            select.Append(" from log_reporte_ministerio ");
            //select.Append(" where trunc(LRMI_FECREGISTRO_DT) between trunc(sysdate-360) and trunc(sysdate) ");
            //select.Append(" where trunc(LRMI_FECREGISTRO_DT) between trunc(sysdate-360) and trunc(sysdate) ");
            select.Append(" where LRMI_TRANSACCION_NB in (3, 4, 5, 6, 9, 32) ");
            select.Append(" AND trunc(LRMI_FECREGISTRO_DT) between trunc(sysdate-1) and trunc(sysdate) ");
            //select.Append(" AND LRMI_SECUENCIA_NB < 2748802");
            select.Append(" and LRMI_ESTADO_V2 in ('U') ");
            select.Append(" order by 3; ");
            select.Append(" END; ");
            return select.ToString();
        }
        private string getLogReporteMinisterioTransaccionLlave()
        {
            StringBuilder select = new StringBuilder();
            select.Append(" declare ");
            select.Append(" begin ");
            select.Append(" open :refcur1 for ");
            select.Append(" select LRMI_SECUENCIA_NB,  ");
            select.Append(" LRMI_OFICINA_NB, ");
            select.Append(" LRMI_TRANSACCION_NB, ");
            select.Append(" LRMI_LLAVE_V2, ");
            select.Append(" LRMI_FECREGISTRO_DT, ");
            select.Append(" LRMI_ESTADO_V2, ");
            select.Append(" LRMI_CAMPO1_NB, ");
            select.Append(" LRMI_CAMPO2_V2, ");
            select.Append(" LRMI_CAMPO3_DT  ");
            select.Append(" from log_reporte_ministerio  ");
            select.Append(" where LRMI_TRANSACCION_NB =:LRMI_TRANSACCION  ");
            select.Append(" and LRMI_LLAVE_V2=:LRMI_LLAVE  ");
            select.Append(" order by LRMI_FECREGISTRO_DT;  ");
            select.Append("end;");
            return select.ToString();
        }
    }
}

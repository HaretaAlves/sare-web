using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Utils
{
    public static class Constants
    {
        public const string NOLAYOUT = "NOLAYOUT";

        public const string KEY_ERROR_MESSAGE = "ERROR_MESSAGE_KEY";
        public const string KEY_SUCCESS_MESSAGE = "KEY_SUCCESS_MESSAGE";

        public const string LOGIN_DENIED = "Login ou senha inválido";
        public const string LOGIN_REMEMBER_PASS_SENT = "Senha enviada com sucesso";
        public const string LOGIN_INVALID_EMAIL = "Usuário não encontrado!";
        public const string LOGIN_DUPLICATED_EMAIL = "Usuário utilizado em mais de um registro. Contate o administrador.";

        public const string GENERIC_MSG_FORM_SUCCESS_SAVE = "Registro salvo com sucesso.";
        public const string GENERIC_MSG_FORM_SUCCESS_SAVE_MANY_ITENS = "Registros salvos com sucesso.";
        public const string GENERIC_MSG_FORM_SUCCESS_ADD = "Registro cadastrado com sucesso.";
        public const string GENERIC_MSG_FORM_SUCCESS_UPDATE = "Registro alterado com sucesso.";
        public const string GENERIC_MSG_FORM_SUCCESS_DELETE = "Registro excluído com sucesso.";
        public const string GENERIC_MSG_FORM_ITEM_NOT_FOUND = "Item não encontrado.";
        public const string GENERIC_MSG_FORM_DATA_SAVED = "Dados salvos com sucesso";
        public const string GENERIC_MSG_ERROR_SEND_DATA_POST = "Erro ao enviar os dados para o servidor";
        public const string GENERIC_PERMISSION_DENIED = "Você não tem permissão para realizar essa operação";
    }
}
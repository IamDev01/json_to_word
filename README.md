# Gerador de Relatório Médico

Este é um aplicativo de Windows Forms que gera relatórios médicos personalizados a partir de dados em formato JSON.  
O programa permite aos usuários gerar relatórios com base nas informações inseridas no arquivo JSON, como dados do paciente, resultados de exames e outros detalhes médicos.

O aplicativo também inclui um instalador para facilitar a instalação e a distribuição em outros computadores.

### Funcionalidades
Entrada de Dados: O usuário insere os dados no formato JSON.  
*Para testar o programa insira o seguinte texto json no campo de entrada*
```
{
  "nome": "João Silva",
  "idade": 45,
  "diagnostico": "Hipertensão",
  "prescricao": "Losartana 50mg, 1 comprimido ao dia",
  "exames": [
    {"tipo": "Hemograma", "resultado": "Normal"},
    {"tipo": "Colesterol", "resultado": "Alto"}
  ]
}
```
Botão para gerar relatório: Após acionar o botão, o programa irá verificar a entrada de dados, se estiver tudo certo, será aberto a opção de salvar o arquivo já convertido word.

### Pré-requisitos  

Microsoft .NET Framework 4.8.  
Microsoft Visual Studio (Recomendado para execução e desenvolvimento).  

### Direitos Autorais  

Copyright (c) 2025 Héricles França da Silva. Todos os direitos reservados.

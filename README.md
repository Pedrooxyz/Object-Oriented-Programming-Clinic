# Introdução

## 1.1 Contextualização

No segundo ano da Licenciatura em Engenharia de Sistemas Informáticos, no âmbito da unidade curricular de Programação Orientada a Objetos, foi realizado um projeto prático individual utilizando a linguagem C#. Este projeto foi desenvolvido em duas fases distintas ao longo do período letivo do primeiro semestre, com documentação e implementação de conceitos fundamentais da Programação Orientada a Objetos (POO).

## 1.2 Problema e Descrição do Projeto

Este projeto tem como objetivo desenvolver um sistema de gestão de uma clínica médica, permitindo o registo e a manipulação de dados de pacientes, consultas e médicos. Durante o desenvolvimento, são aplicados os quatro pilares da Programação Orientada a Objetos (POO):

- **Encapsulamento**: Protege o acesso direto aos atributos e assegura a integridade dos dados através do uso de propriedades e métodos de acesso.
- **Herança**: Criação de classes especializadas a partir de classes genéricas, promovendo a reutilização de código.
- **Polimorfismo**: Permite que diferentes classes utilizem métodos com o mesmo nome, mas com comportamentos distintos, aumentando a flexibilidade e reutilização de código.
- **Abstração**: Fornece apenas as informações essenciais de um objeto, ocultando os detalhes internos de implementação.

Inicialmente, será necessário formular e definir as estruturas de dados adequadas para a gestão de informações da clínica. O sistema permitirá realizar operações como criação, modificação e visualização de dados de pacientes, consultas e médicos. Com a evolução do projeto, será necessária a remoção de pacientes e consultas, além da implementação de listas dinâmicas para armazenamento e manipulação dos dados.

# Objetivos

O objetivo principal do presente trabalho é a consolidação do conhecimento sobre estruturas de classes e dados em C#, através da prática no desenvolvimento de uma solução de gestão de dados para uma clínica médica. Entre os objetivos específicos, destacam-se:

- Aprimorar a compreensão e a aplicação da Programação Orientada a Objetos (POO), com foco em herança, polimorfismo, encapsulamento e abstração.
- Estruturar e organizar as classes e objetos de forma eficiente e escalável.
- Implementar funcionalidades básicas, como inserção, remoção e atualização de dados dos pacientes e consultas.
- Aplicar princípios de **Design Patterns** e boas práticas no desenvolvimento do sistema, garantindo um código modular e de fácil manutenção.

# Fundamentos

## 3.1 Programação Orientada a Objetos

A Programação Orientada a Objetos (POO) permite modelar sistemas de software com base em entidades do mundo real, utilizando conceitos como objetos e classes.

**Principais conceitos da POO:**

- **Encapsulamento**: Restrição do acesso direto aos atributos internos da classe, expondo apenas o essencial.
- **Herança**: Reutilização de código ao criar novas classes com base em outras já existentes.
- **Polimorfismo**: Permite que métodos com o mesmo nome tenham diferentes implementações dependendo do contexto.
- **Abstração**: Oculta detalhes internos de implementação, permitindo uma interação mais intuitiva com os objetos.

## 3.2 Design Patterns

Os **Design Patterns** são modelos de soluções para problemas recorrentes no desenvolvimento de software. Alguns padrões importantes incluem:

- **Singleton**: Garante que uma classe tenha apenas uma instância e fornece um ponto global de acesso a ela.
- **Factory Method**: Permite criar objetos sem especificar a classe exata.
- **Observer**: Define uma dependência entre objetos, garantindo que uma mudança em um objeto notifique automaticamente os dependentes.
- **MVC (Model-View-Controller)**: Estrutura uma aplicação em três camadas:
  - **Model**: Gerencia os dados e regras de negócio.
  - **View**: Responsável pela interface do utilizador.
  - **Controller**: Lida com as interações do utilizador e atualiza a View e o Model.

## 3.3 Arquitetura N-Tier

A arquitetura **N-Tier** permite a divisão do código em diferentes camadas, separando claramente as responsabilidades. Um dos modelos mais comuns é a **arquitetura em três camadas (3-tier)**, composta por:

- **Camada de Apresentação (View)** - Responsável por exibir informações e interagir com o utilizador.
- **Camada de Lógica de Negócio** - Implementa as regras do negócio e lógica do sistema.
- **Camada de Acesso a Dados** - Responsável pela comunicação com a base de dados.

Esta estrutura melhora a organização do código, a escalabilidade e a manutenção da aplicação.

## 3.4 Importância dos Padrões de Projeto (Design Patterns) na POO

Os padrões de design (**Design Patterns**) são soluções reutilizáveis para problemas recorrentes em projetos de software. Permitem criar código mais modular, reutilizável e de fácil manutenção. Existem três categorias principais de **Design Patterns**:

- **Criacionais**: Abordam a criação de objetos de maneira flexível e eficiente (ex.: Singleton, Factory, Builder).
- **Estruturais**: Ajudam a organizar e estruturar classes e objetos (ex.: Adapter, Decorator, Composite).
- **Comportamentais**: Facilitam a comunicação entre objetos e definem padrões de interação (ex.: Strategy, Observer, Command).

Os princípios **SOLID** também são fundamentais na POO e incentivam a criação de código mais modular, reutilizável e fácil de manter. Esses princípios são:

- **Single Responsibility Principle**: Cada classe deve ter uma única responsabilidade.
- **Open/Closed Principle**: O software deve ser aberto para extensão, mas fechado para modificação.
- **Liskov Substitution Principle**: Os objetos de uma classe derivada devem ser substituíveis pelos da classe base sem afetar a funcionalidade do sistema.
- **Interface Segregation Principle**: Uma classe não deve ser forçada a depender de métodos que não usa.
- **Dependency Inversion Principle**: Depender de abstrações em vez de implementações concretas.


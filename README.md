# GyroTwist #

Aplicação desenvolvida para a matéria de Software para Smartphones lecionada pelo professor Sérgio Barbosa Villas-Boas.
É um jogo do tipo "Infinite Runner", mas, nesse caso, o jogo é 2D, em que a mecânica principal e única é girar o celular
para poder prosseguir sobre as plataformas que forem aparecendo pela frente. A pontuação dependerá do tempo em que o jogador
conseguir sobreviver.


### Tecnologias utilizadas ###

* Unity 5.2.1f1 (64-bit)
* PHP 5

O jogo foi todo desenvolvido em Unity utilizando a linguagem C#. 
A parte cloud do projeto utiliza um script PHP que organiza e disponibiliza as 8 melhores pontuações obtidas no jogo 
por todos que o tiverem jogado.

### Exportando para Android ###

Para exportar para Android, basta importar esse repositório para uma máquina qualquer que possua o motor Unity instalado (versão >=5.2.1f1).
Em seguida, abra esse projeto pelo Unity e execute os seguintes comandos:

1) Clique na opção "File" > "Build Settings...";

2) Em "Platform" selecione "Android";

3) Clique em "Build";

Assim, um .apk será gerado e basta colocá-lo no seu android, instalar e jogar!

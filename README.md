# Football Transfer Decision Support Software

**Object of study** is the process of estimating the transfer value of football players.

**The purpose of the work** is to develop decision support software on football transfer activity for determination the price of a player on the transfer market
to automate this process according to the assessment of his performance by football experts.

<details open="open">
  <summary>Table of Contents</summary>
  <ol>
    <li><a href="#core-functionality">Core functionality</a></li>
    <li><a href="#technology">Technology</a></li>
    <li><a href="#complementary-approaches">Complementary approaches</a></li>
    <li><a href="#project-overview">Project overview</a></li>
    <li>
      <a href="#application-architecture">Application architecture</a>
      <ul>
        <li><a href="#server-side">Server-side</a></li>
        <li><a href="#client-side">Client-side</a></li>
      </ul>
    </li>
    <li><a href="#analysis-of-transfer-market-trends">Analysis of transfer market trends</a></li>
    <li>
      <a href="#mathematical-model">Mathematical model</a>
      <ul>
        <li><a href="#dataset-and-preprocessing">Dataset and preprocessing</a></li>
        <li><a href="#model-configuration">Model configuration</a></li>
        <li><a href="#learning-and-results">Learning and results</a></li>
      </ul>
    </li>
    <li><a href="#results">Results</a></li>
  </ol>
</details>

<!-- CORE FUNCTIONALITY -->
<h2 id="core-functionality">Core functionality</h2>

The central functionality of the application involves the assessment of player performance. Users can create their own evaluations based on an internal rating system. This information is then used to determine the player's current transfer value based on a developed mathematical model.

![Player assesment](https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/Player%20assesment.gif)

In addition, users are able to manage footballer information by adding, removing, or editing records, thus filling the pool of footballers available for evaluation.

![Working with player](https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/Working%20with%20player.gif)


The application implements a client-side architecture, which permits multiple users to interact with the system concurrently. The host-side component of the application maintains a log of user activities.

![image](https://user-images.githubusercontent.com/50755505/235563408-df3edb38-7367-40c1-a417-f84158ef325d.png)


<!-- TECHNOLOGY -->
<h2 id="technology">Technology</h2>

<code><img height="50" src="https://user-images.githubusercontent.com/25181517/121405384-444d7300-c95d-11eb-959f-913020d3bf90.png" alt="C#" title="C#" /></code>
<code><img height="50" src="https://user-images.githubusercontent.com/25181517/121405754-b4f48f80-c95d-11eb-8893-fc325bde617f.png" alt=".NET Core" title=".NET Core" /></code>
<code><img height="50" src="https://user-images.githubusercontent.com/25181517/183423507-c056a6f9-1ba8-4312-a350-19bcbc5a8697.png" alt="Python" title="Python" /></code>


<code><img height="50" src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/icons/XAML%20logo.png" alt="XAML" title="XAML" /></code>
<a href="https://learn.microsoft.com/en-us/dotnet/desktop/wpf/?view=netdesktop-7.0"><code><img height="50" src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/icons/WPF%20logo.png" alt="WPF" title="WPF" /></code></a>

<a href="https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel"><code><img height="50" src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/icons/MVVM%20logo.png" alt="MVVM" title="MVVM" /></code></a>

<code><img height="50" src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/icons/SQL%20Server%20logo.png" alt="SQL Server" title="SQL Server" /></code>

<a href="https://learn.microsoft.com/en-us/dotnet/framework/wcf/whats-wcf"><code><img height="50" src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/icons/WCF%20logo.jpg" alt="WCF" title="WCF" /></code></a>


<a href="https://www.tensorflow.org/"><code><img height="50" src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/icons/Tensorflow%20logo.png" alt="TensorFlow" title="TensorFlow" /></code></a>
<a href="https://keras.io"><code><img height="50" src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/icons/Keras%20logo.png" alt="Keras" title="Keras" /></code></a>

<a href="https://www.spyder-ide.org/"><code><img height="50" src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/icons/Spyder%20logo.png" alt="Spyder" title="Spyder" /></code></a>
<code><img height="50" src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/icons/MVS%20logo.jpg" alt="Microsoft Visual Studio" title="Microsoft Visual Studio" /></code>

<!-- COMPLEMENTARY APPROACHES -->
<h2 id="complementary-approaches">Complementary approaches</h2>

- Data parsing
- Correlation analysis
- Multilayer neural network
- Supervised learning
- Wisdom of crowd

<!-- PROJECT OVERVIEW -->
<h2 id="project-overview">Project overview</h2>

- ```TransferMarket``` is a project comprising both server and client-side applications, designed to provide users with an interactive experience when accessing the developed functionality.

- ```transfer-market-model``` is a comprehensive toolset for data retrieval, standardization, pre-processing, rendering, and neural network modeling.

- ```transfer-market-statistics``` is a repository of football transfer market data analysis and visualization tools, including graphs and histograms that depict its evolution over the years.

<!-- APPLICATION ARCHITECTURE -->
<h2 id="application-architecture">Application architecture</h2>

<h3 id="server-side">Server-side</h3>

Key components of the server-side application:

- **DataBase**: This component connects to the ```SQL Server``` database, which stores data in an ```.mdf``` file format.
- **DataLevel**: This component consists of a set of attributes and methods that work with data stored in the DB.
- **NeuralNetwork**: This component stores all parameters and functions required for the integration of the mathematical model of the system, which predicts the price of football players. It calls the corresponding Python script, ```finalpredict.py```, located in a virtual Python environment. This script uses a neural network model created with ```Keras``` and saved in a ```.h5``` format.
- **PlayerService**: This component provides an API that clients can use directly.
- **ServiceHost**: This component is responsible for deploying the server.

Explore the corresponding [class-hierarchy](https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/Server%20class%20diagram.png).
</br>
</br>

<div align="center">
  <img
       src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/Server%20side%20structural%20diagram.png"
       width="80%"
       height="80%"
       alt="Server-side architecture">
</div>

$$\textcolor{#454545}{Server-side \ structural \ diagram.}$$

<h3 id="client-side">Client-side</h3>

- **View** layer is responsible for the graphical representation and interaction with user.
  - ```Windows``` include classes describing windows and other objects of the user interface, connected to them using declarative style.
  - ```Pages``` describe the interface pages and their corresponding navigation. Pages contain descriptions of significant user interface elements.
  - ```Themes``` are descriptions of styles, also known as ```resources```, that are assigned to interface objects.
  - ```UserControls``` are components with corresponding layout and data binding descriptions created directly by the developer.

- **ViewModel**, or the representation model, links the model and representation through the ```data binding``` mechanism. Each ```ViewModel``` should inherit the ```ViewModelBase``` class specifically for binding. ```RelayCommand``` is used to organize commands.
  - ```Validation``` is a class that contains descriptions of validation rules for corresponding ```ViewModel``` fields. Here ```DataAnnotations``` component was used.
  - ```Converters``` are used in case it is necessary to bind several parameters to the interface at once (to one control element), or if it is necessary to perform type conversions directly in the layout, or to compare the values of the representation element parameters.

- In the **Model** layer, it is necessary to describe the basic entities of the model. All entities of the Model component inherit ```ModelBase```. The main entities include:
  - ```User``` and its derivatives
  - ```Player``` - the central class of the program
  - ```Nationality``` or ```Team``` - auxiliary entities

Explore the corresponding [class-hierarchy](https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/ViewModel%20class%20diagram.png).
</br>
</br>

![Client-side](https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/Client%20side%20structural%20diagram.png)

$$\textcolor{#454545}{Client-side \ structural \ diagram.}$$

<!-- ANALYSIS OF TRANSFER MARKET TRENDS -->
<h2 id="analysis-of-transfer-market-trends">Analysis of transfer market trends</h2>

To demonstrate the relevance of this study, an analysis of the football transfer market in recent years was conducted using [comprehensive statistics](https://github.com/ewenme/transfers) provided by [@ewen](https://github.com/ewenme).

Over 5 years in the top 5 European championships both club revenues and transfer spending have grown. Although their ratio was not constant, the share of transfer spending in club revenues increased from 23% to 36%.

<div align="center">
  <img
       src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/Revenue%20spending%20ratio.png"
       width="80%"
       height="80%"
       alt="Revenue and spending">
</div>

$$\textcolor{#454545}{Clubs \ allocate \ larger \ budgets}$$

Moreover, it was found that the average transfer fee and the maximum transfer fee have increased. Over the past 25 years: the number of transfers has increased fourfold; transfer spending has increased 110 times.

<div align="center">
  <img
       src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/Clubs%20transfer%20spending.png"
       width="80%"
       height="80%"
       alt="Clubs transfer spending">
</div>

$$\textcolor{#454545}{Significant \ growth \ of \ the \ transfer \ market}$$

Nevertheless, there has been a growing tendency among clubs to prevent financial crises by implementing a competent transfer policy and succeeding not just by relying on homegrown players but also by acquiring the best talent available. The Football Observatory CIES and Transfermarkt are actively working to address a similar issue.

1. [The Football Observatory](https://football-observatory.com) collects statistical data on football players based on specific football matches and uses this data for a predictive model that determines the players transfer value.

2. [Transfermarkt](https://www.transfermarkt.com) determines the value of football players using the "wisdom of crowds" method - averaging individual expert ratings, without using an algorithm. Instead  of a model, a human establishes the final result.

The developed system combines the advantages of both methods.

<!-- MATHEMATICAL MODEL -->
<h2 id="mathematical-model">Mathematical model</h2>

<h3 id="dataset-and-preprocessing">Dataset and preprocessing</h3>

Mathematical model incorporates expert knowledge instead of statistical data to automate the process of determining football player values.

The data was retrieved from the [FIFA 2021](https://sofifa.com/players) football simulator. The final dataset contains ratings for each player's performance across 31 features.

<div align="center">
  
  | Feature | Description                               | Scale |
  |--------------------------|:------------------------------------------:|-----------:|
  | Overall rating           | Average player skills rating               | 0-99       |
  | Potential                | Possible additional rating                 | 0-99       |
  | Skill moves              | Distinguishes strong players from big ones | 1-100      |
  | International reputation | Player's popularity indicator              | 1-100      |
  | ...                      | ....                                       | ...        |
  | Price                    | Transfer value                             | 0-5∗10^8   |
  
</div>

$$\textcolor{#454545}{Subset \ of \ initial \ data }$$

Those features were normalized using z-score normalization. The output feature has lognormal distribution, which requires log-normalization to accurately predict the value of expensive players.

<div align="center">
  <img
       src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/Log%20normalization%20of%20objective%20feature.png"
       width="80%"
       height="80%"
       alt="Normalization">
</div>

$$\textcolor{#454545}{Output \ feature \ before \ and \ after \ normalization }$$

Features that are collinear or highly correlated with the output will be removed to improve the generalization and interpretability of the model.

![Correlation Heatmap](https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/Correlation%20Heatmap.png)

$$\textcolor{#454545}{Correlation \ heatmap }$$

<h3 id="model-configuration">Model configuration</h3>

A neural network was used to establish the relationship between independent features and the target variable for a regression task. When classifying the problem as a non-linear regression task, a multi-layer neural network with a non-linear activation function is typically used.

The final configuration of neural network:
- Synaptic connection matrix = [31 625 250 1];
- ReLU activation function for hidden layers, linear activation function for output layer;
- MSE error function;
- Adam optimizer;
- Convergence step λ = 0.001;
- Training epoch - 30, batch size - 20.

<h3 id="learning-and-results">Learning and results</h3>

The learning is performed on a sample of 15233 objects, each of which has values for 31 independent features and 1 dependent feature.
The training sample is shuffled. The initial sample is divided into a training and testing set in an approximate ratio of 15-20% to 85-80%.

To analyze the accuracy of the obtained model, the coefficient of determination $R^2$ is used. It characterizes the portion of the feature variance explained by the regression in the total variance of the feature.

As a result of parameter synthesis, the weight coefficients of the model are determined. The coefficient of determination of the predicted player price is $R^2 = 0.900$.

<div align="center">
  <img
       src="https://github.com/sergey-lipikhin/football-transfer-decision/blob/main/description/Learning%20results.png"
       alt="Learning relults">
</div>

$$\textcolor{#454545}{Final \ performance }$$

<!-- Results -->
<h2 id="results">Results</h2>

**Results.** The possibility of combining two fundamental methods of determining the transfer value of a player – mathematical model and the "wisdom of crowd" is implemented.

**Conclusions.** A software system has been developed to rate the game characteristics of football players and evaluate on the basis of such estimates of the market value of players.

**The field of use** is transfer negotiations between clubs’ representatives and intermediaries, football analytics by experts and leisure of fans.

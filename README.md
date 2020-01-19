# LightsOut
## Lights Out Puzzle Game

[![Build Status](https://dev.azure.com/hibbardsimon/hibbardsimon/_apis/build/status/shibbard.LightsOut?branchName=master)](https://dev.azure.com/hibbardsimon/hibbardsimon/_build/latest?definitionId=1&branchName=master)

Quick web app written for as part of an assignment. CI/CD implemented via MS Azure Pipelines, commit to master will trigger build, unit testing and deployment to the Azure web app.

Published app: [https://lightsoutapp.azurewebsites.net/](https://lightsoutapp.azurewebsites.net/)

Statefullness implemented using sessions, and supported using DI so it can be stubbed out in Unit Testing.

UI was not required but implemented as it is a simple few lines of HTML/CSS, CSS Grid used to render it.

Caveats:
- IE not supported (requires work on the CSS grid)
- Unit test coverage minimal
- UI is minimal, e.g. clicking on a light uses full refresh rather than Ajax, no use controls, not polished styling
- UI is not responsive


## Local Grafana + Tempo + Loki

You can use `docker-compose.yml` file to run all required application to be able to see logs and traces locally.

#### Steps:
* Open CMD in the current folder
* Run command `docker-compose up -d`
    * If you want to re-run: 
        * CMD: `docker-compose down && docker-compose up -d`
        * PowerShell: `docker-compose down; docker-compose up -d`
* Navigate to Grafana dashboard: http://localhost:3000/
* Navigate to menu `Explore`.
* Use `Tempo` to see traces.
* Use `Loki` to see logs.

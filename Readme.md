## Grafana + Tempo + Loki + Prometheus

- Grafana - Dashboard visualization
- Tempo - Traces
- Loki - Logs
- Prometheus - Metrics

### Built-in Dashboards
- ASP.NET Core
- ASP.NET OpenTelemetry dotnet webapi
- ASP.NET OTEL Metrics

### Steps to Run:
1. Open CMD or PowerShell in the current folder.
1. Run `docker-compose up -d` to start the services.
    - To restart the services:
        - CMD: `docker-compose down && docker-compose up -d`
        - PowerShell: `docker-compose down; docker-compose up -d`
1. Open your browser and navigate to the Grafana dashboard: [http://localhost:3000/](http://localhost:3000/).
1. Use the `Explore` or `Dashboards` menu in Grafana:
    - Use `Tempo` to view traces.
    - Use `Loki` to view logs.
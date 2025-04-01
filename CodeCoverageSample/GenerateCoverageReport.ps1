dotnet test -- --coverage --coverage-output-format xml --coverage-output coverage.xml

ReportGenerator -reports:Tests\bin\Debug\net8.0\TestResults\coverage.xml -targetdir:CoverageReport

.\CoverageReport\index.html
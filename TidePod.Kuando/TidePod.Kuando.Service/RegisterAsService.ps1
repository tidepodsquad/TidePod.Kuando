# Put this script & the service executable in the folder the service should run from, and then run this script to register the service.
$location = Get-Location
New-Service -name "TidePod Kuando Master Control" -binaryPathName "$location\TidePod.Kuando.Service.exe"
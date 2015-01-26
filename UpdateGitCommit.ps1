param($Commit)

Write-Output "DEPLOYMENT_TARGET: '$env:DEPLOYMENT_TARGET'"

Write-Output "Commit: '$Commit'"

$webConfig = "$env:DEPLOYMENT_TARGET\Web.config"

$doc = (Get-Content $webConfig) -as [Xml]

$node = $doc.configuration.appSettings.add | where Key -EQ "appharbor.commit_id"

$node.Value = $Commit

$doc.Save($webConfig)

Write-Output "Completed App setting update"
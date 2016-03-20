@ApiAcceptanceTests
#prerequisite:  in order to run these tests, the public IP address used by the development machine must be whitelisted on database.
Feature: UrlCodec
	In order shortenUrls
	As a hosted Azure Service
	I want to be able to convert between URLs and short-codes
	
@HappyPath
Scenario Outline: Urls Can be encoded into short-codes
	Given A user wants to encode the URL: '<url>'
	When the requesting service submits a POST request to encode the URL
	Then the codec service returns a code and 'Success' status
	Examples: 
	| url                                                                                                                      |
	| https://home.stevenfarnell.net/<TIMESTAMP>                                                                               |
	| https://www.google.com/webhp?sourceid=chrome-instant&ion=1&espv=2&es_th=1&ie=UTF-8#q=test%20search%20terms%20<TIMESTAMP> |

@HappyPath
Scenario: short-codes can be converted back into URLs
	Given A user wants to retrieve a URL from a '1y5a'
	When the requesting service submits a GET request is send for the short-code
	Then the codec service returns the URL 'home.stevenfarnell.net'


Scenario: short-codes that don't exist return No rows found
	Given A user wants to retrieve a URL from a 'za1y5a'
	When the requesting service submits a GET request is send for the short-code
	Then the codec service returns the URL 'No rows found'

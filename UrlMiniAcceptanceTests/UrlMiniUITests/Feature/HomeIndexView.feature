@UIAcceptanceTests
Feature: HomeIndexView
	In order to obtain and use short codes
	As an end user
	I want to be able to submit Urls and use the short code

@HappyPath
Scenario Outline: The user obtains a short code when they submit a valid URL
	Given the user has a URL '<url>' that they want to have shortened
	When the user navigates to the home page and enters a URL to shorten
	When the user clicks Shorten Url
	Then a short-code is generated in the output area
	Then Clicking the short-code link takes the user to the desired page
	Examples: 
	| url                                                                                                                      |
	| https://home.stevenfarnell.net/                                                                                          |
	| http://home.stevenfarnell.net/                                                                                           |
	| https://www.google.com/webhp?sourceid=chrome-instant&ion=1&espv=2&es_th=1&ie=UTF-8#q=test%20search%20terms%20<TIMESTAMP> |
	| http://www.google.com                                                                                                    |
	| HTTPS://www.google.com/webhp?sourceid=chrome-instant&ion=1&espv=2&es_th=1&ie=UTF-8#q=test%20search%20terms%20<TIMESTAMP> |
	| HTTP://home.stevenfarnell.net                                                                                           |


@HappyPath
Scenario: The user is redirected to the desired page when they load the shortlink
	Given the user has a short-code '1y5a'
	When the user attempts to navigate to the short-code Url
	Then the user is redirected to the 'https://home.stevenfarnell.net/' page

@Negative
Scenario Outline: The user is not able to submit an invalid URL
	Given the user has a invalid URL '<url>' that they want to have shortened
	When the user navigates to the home page and enters a URL to shorten
	Then the Shorten URL button is disabled
	Examples: 
	| url                  |
	| invalid              |
	| https:incomplete     |
	| http://"noquotes     |
	| https:// no spaces   |
	| ftp://unsupportedUrl |

#@Negative
#Scenario: The user is given a graceful error when they attempt to load an invalid shortlink
#	Given the user has a short-code '1y5b'
#	When the user attempts to navigate to the short-code Url
#	Then the user is redirected to the '' error page

@Negative
Scenario Outline: The user receives a graceful error when they attempt to load an invalid shortlink
	Given the user has a short-code '<code>'
	When the user attempts to navigate to the short-code Url
	Then the user is redirected to the '<ErrorType>' error page
	Examples: 
	| code    | ErrorType                     |
	| 1y5b    | Not Found                     |
	| ag4j!   | Not Found                     |
	| asd-b   | Not Found                     |
	| zzzA    | Not Found                     |
	| hhh}j   | Not Found                     |
	| aBc3ff  | Not Found                     |
	| `fbse   | Not Found                     |
	| 'gwno   | Not Found                     |
	| $bdf    | Not Found                     |
	| -bar    | Not Found                     |
	| foO     | Not Found                     |
	| abcdefg | Not Found                     |

#These Scenarios are ignored because they are handled by IIS and Azure:
#	| da&fb   | A potentially dangerous Path  |
#	| bs+4d   | Error - 404.11 - Not Found    |
#	| ho/pd   | The resource cannot be found. |
#	| ?hopd   |
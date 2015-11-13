# csharpmodules
A collection of c# interfaces/classes that are useful enough to collate.

# Structure

Each area of development should have it's own folder e.g. a module that interacts with the filesystem should be filed under the folder `filesystem`.

## Tests

Tests for each module (if available) will exist under the `tests` directory in a folder named after their parent folder structure e.g. the test file for `/exception/ExceptionHandler.cs` is situated in `tests/exception/ExceptionHandlerTests.cs`.

### Frameworks used for testing
* Xunit
* Moq
* Ploeh.AutoFixture
* Ploeh.AutoMoq

*Note that we are not limiting/enforcing ourselves in using these frameworks. Any framework can be used as long as the using statements for said framework is included in the test module.*

# Contributing

If your module doesn't fit within any of the existing folder areas, create a new one within your pull request.

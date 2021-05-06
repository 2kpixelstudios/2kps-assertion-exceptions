# 2kPS Assertion Exceptions

2kPS.AssertionExceptions is a small library that allows developers to write debugging assertions in more than just unit tests.

The assertions will help in Debug builds, but will stripped from Release builds.

**Note:** For packaging and pushing this project as a Nuget package,
`Debug` configuration must be used, so that the `[Conditional("DEBUG")]` methods are actually included.

- These methods will be properly stripped out of `Release` builds in projects that use `2kPS.AssertionExceptions` as a NuGet package.
- Projects that use `2kPS.AssertionExceptions` should NOT conditionally include the package reference to `2kPS.AssertionExceptions` -- this is already handled by the methods that have `[Conditional("DEBUG)]` on them.

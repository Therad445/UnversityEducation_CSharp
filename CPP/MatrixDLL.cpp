#include "Matrix.h"

extern "C" __declspec(dllexport) double SolveRepeatCPP(int, int);
extern "C" __declspec(dllexport) void SolveMatrixCPP(int, double*, double*, double*);

double SolveRepeatCPP(int matrixOrder, int repetitionCount) {
	Matrix matrix(matrixOrder);
	auto b = new double[matrixOrder]; // right part
	auto x = new double[matrixOrder]; // array for answers
	for (auto i = 0; i < matrixOrder; i++) b[i] = rand() % 11 + static_cast<double>(rand()) / RAND_MAX;

	auto start = clock();
	for (auto i = 0; i < repetitionCount; i++) {
		matrix.Solve(b, x);
	}
	auto stop = clock();
	
	delete[] b;
	delete[] x;

	return (static_cast<double>(stop) - start) * 1000 / CLOCKS_PER_SEC;
}

void SolveMatrixCPP(int matrixOrder, double* sourceMatrix, double* right, double* ans) {
	Matrix matrix(matrixOrder, sourceMatrix);
	matrix.Solve(right, ans);
}